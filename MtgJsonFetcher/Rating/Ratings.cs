using System.Text.Json;
using MtgJsonFetcher.Rating.Types;

namespace MtgJsonFetcher.Rating;

/// <summary>
/// Static client for loading card ratings based on a filter.
/// Maintains local cache to only hit network once per day for each unique filter combination.
/// </summary>
public static class Ratings
{
    private static readonly HttpClient HttpClient = new();
    private const string DateFormat = "yyyy-MM-dd";

    /// <summary>
    /// Loads ratings based on filter.
    /// Maintains local cache to only hit network once for each unique filter combination.
    /// </summary>
    /// <param name="option">Filters to apply when fetching data.</param>
    /// <returns>List of ratings.</returns>
    public static async Task<List<CardRatings>> Load(Action<RatingsFilter>? option = null)
    {
        var filter = new RatingsFilter();
        option?.Invoke(filter);

        var cacheFileName = BuildCacheFileName(filter);
        var ratings = await LoadFromCache(cacheFileName);

        if (ratings == null)
        {
            ratings = await FetchViaNetwork(filter, cacheFileName);
        }

        ratings = ApplyClientSideFilter(ratings, filter);

        if (ratings == null)
        {
            ratings = new List<CardRatings>();
        }

        return ratings;
    }

    private static List<CardRatings>? ApplyClientSideFilter(List<CardRatings>? list, RatingsFilter filter)
    {
        if (list == null)
        {
            return null;
        }

        if (filter.Color != Color.Any)
        {
            list = list.Where(r => r.Color == filter.Color.ToString()).ToList();
        }

        if (filter.Rarity != Rarity.Any)
        {
            list = list.Where(r => r.Rarity == filter.Rarity.ToString().ToLower()).ToList();
        }

        return list;
    }

    private static async Task<List<CardRatings>?> FetchViaNetwork(RatingsFilter filter, string fileName)
    {
        var url = BuildUrlQuery(filter);

        var response = await HttpClient.GetAsync(url);
        if (response.IsSuccessStatusCode == false)
        {
            return null;
        }

        var content = await response.Content.ReadAsStringAsync();
        await File.WriteAllTextAsync(fileName, content);
        var fresh = JsonSerializer.Deserialize<List<CardRatings>>(content);

        return fresh;
    }

    private static string BuildUrlQuery(RatingsFilter filter)
    {
        var url = "https://www.17lands.com/card_ratings/data" +
                  $"?expansion={filter.Expansion}" +
                  $"&format={filter.Format}" +
                  $"&start_date={filter.Start.ToString(DateFormat)}" +
                  $"&end_date={filter.End.ToString(DateFormat)}";

        if (filter.UserGroup != UserGroup.Any) url += $"&user_group={filter.UserGroup}";
        if (filter.Decks != Decks.Any) url += $"&colors={filter.Decks}";

        return url;
    }

    private static async Task<List<CardRatings>?> LoadFromCache(string fileName)
    {
        if (!File.Exists(fileName))
        {
            return null;
        }

        var json = await File.ReadAllTextAsync(fileName);
        var saved = JsonSerializer.Deserialize<List<CardRatings>>(json);

        return saved;
    }

    private static string BuildCacheFileName(RatingsFilter filter)
    {
        var propertiesAsNameAndValue = filter
            .GetType()
            .GetProperties()
            .Select(p => $"{p.Name}{p.GetValue(filter, null)?.ToString()?.Replace("/", "-")}");

        var fileName = $"CardRatings_{string.Join("_", propertiesAsNameAndValue)}.json";
        return fileName;
    }
}
