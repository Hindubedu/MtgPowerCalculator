// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace MtgJsonFetcher.Rating.Types;

public class RatingsFilter
{
    public Expansion Expansion { get; set; } = Expansion.ONE;
    public Format Format { get; set; } = Format.PremierDraft;
    public UserGroup UserGroup { get; set; } = UserGroup.Any;
    public Color Color { get; set; } = Color.Any;
    public Decks Decks { get; set; } = Decks.Any;
    public Rarity Rarity { get; set; } = Rarity.Any;
    public DateOnly Start { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1));
    public DateOnly End { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}
