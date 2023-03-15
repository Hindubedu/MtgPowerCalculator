// ReSharper disable NotAccessedPositionalProperty.Global

using System.Text.Json.Serialization;

namespace MtgJsonFetcher.Rating.Types;

public abstract record CardRatings(
    [property: JsonPropertyName("seen_count")] int SeenCount,
    [property: JsonPropertyName("avg_seen")] double AvgSeen,
    [property: JsonPropertyName("pick_count")] int PickCount,
    [property: JsonPropertyName("avg_pick")] double AvgPick,
    [property: JsonPropertyName("game_count")] int GameCount,
    [property: JsonPropertyName("win_rate")] double WinRate,
    [property: JsonPropertyName("sideboard_game_count")] int SideboardGameCount,
    [property: JsonPropertyName("sideboard_win_rate")] double SideboardWinRate,
    [property: JsonPropertyName("opening_hand_game_count")] int OpeningHandGameCount,
    [property: JsonPropertyName("opening_hand_win_rate")] double OpeningHandWinRate,
    [property: JsonPropertyName("drawn_game_count")] int DrawnGameCount,
    [property: JsonPropertyName("drawn_win_rate")] double DrawnWinRate,
    [property: JsonPropertyName("ever_drawn_game_count")] int EverDrawnGameCount,
    [property: JsonPropertyName("ever_drawn_win_rate")] double EverDrawnWinRate,
    [property: JsonPropertyName("never_drawn_game_count")] int NeverDrawnGameCount,
    [property: JsonPropertyName("never_drawn_win_rate")] double NeverDrawnWinRate,
    [property: JsonPropertyName("drawn_improvement_win_rate")] double DrawnImprovementWinRate,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("color")] string Color,
    [property: JsonPropertyName("rarity")] string Rarity,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("url_back")] string UrlBack
);
