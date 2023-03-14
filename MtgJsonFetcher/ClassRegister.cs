// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

using System.Text.Json.Serialization;
using static Wrapper;

public class Wrapper
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Arena
    {
        [JsonPropertyName("boosters")]
        public List<Booster> Boosters { get; } = new List<Booster>();

        [JsonPropertyName("boostersTotalWeight")]
        public int BoostersTotalWeight { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("sheets")]
        public Sheets Sheets { get; set; }
    }

    public class Basic
    {
        //[JsonPropertyName("cards")]
        //public Cards Cards { get; set; }

        [JsonPropertyName("foil")]
        public bool Foil { get; set; }

        [JsonPropertyName("totalWeight")]
        public int TotalWeight { get; set; }
    }

    public class Booster
    {
        [JsonPropertyName("arena")]
        public Arena Arena { get; set; }

        [JsonPropertyName("default")]
        public Default Default { get; set; }
    }

    public class Booster2
    {
        [JsonPropertyName("contents")]
        public Contents Contents { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }
    }

    public class Card
    {
        [JsonPropertyName("artist")]
        public string Artist { get; set; }

        [JsonPropertyName("availability")]
        public List<string> Availability { get; } = new List<string>();

        [JsonPropertyName("boosterTypes")]
        public List<string> BoosterTypes { get; } = new List<string>();

        [JsonPropertyName("borderColor")]
        public string BorderColor { get; set; }

        [JsonPropertyName("colorIdentity")]
        public List<string> ColorIdentity { get; } = new List<string>();

        [JsonPropertyName("colors")]
        public List<string> Colors { get; } = new List<string>();

        [JsonPropertyName("convertedManaCost")]
        public double ConvertedManaCost { get; set; }

        [JsonPropertyName("finishes")]
        public List<string> Finishes { get; } = new List<string>();

        [JsonPropertyName("foreignData")]
        public List<object> ForeignData { get; } = new List<object>();

        [JsonPropertyName("frameVersion")]
        public string FrameVersion { get; set; }

        [JsonPropertyName("hasFoil")]
        public bool HasFoil { get; set; }

        [JsonPropertyName("hasNonFoil")]
        public bool HasNonFoil { get; set; }

        [JsonPropertyName("identifiers")]
        public Identifiers Identifiers { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("layout")]
        public string Layout { get; set; }

        [JsonPropertyName("legalities")]
        public Legalities Legalities { get; set; }

        [JsonPropertyName("manaCost")]
        public string ManaCost { get; set; }

        [JsonPropertyName("manaValue")]
        public double ManaValue { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("printings")]
        public List<string> Printings { get; } = new List<string>();

        [JsonPropertyName("purchaseUrls")]
        public PurchaseUrls PurchaseUrls { get; set; }

        [JsonPropertyName("rarity")]
        public string Rarity { get; set; }

        [JsonPropertyName("rulings")]
        public List<object> Rulings { get; } = new List<object>();

        [JsonPropertyName("setCode")]
        public string SetCode { get; set; }

        [JsonPropertyName("subtypes")]
        public List<string> Subtypes { get; } = new List<string>();

        [JsonPropertyName("supertypes")]
        public List<string> Supertypes { get; } = new List<string>();

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("types")]
        public List<string> Types { get; } = new List<string>();

        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        [JsonPropertyName("edhrecRank")]
        public int? EdhrecRank { get; set; }

        [JsonPropertyName("flavorText")]
        public string FlavorText { get; set; }

        [JsonPropertyName("keywords")]
        public List<string> Keywords { get; } = new List<string>();

        [JsonPropertyName("power")]
        public string Power { get; set; }

        [JsonPropertyName("toughness")]
        public string Toughness { get; set; }

        [JsonPropertyName("variations")]
        public List<string> Variations { get; } = new List<string>();

        [JsonPropertyName("isStorySpotlight")]
        public bool? IsStorySpotlight { get; set; }

        [JsonPropertyName("frameEffects")]
        public List<string> FrameEffects { get; } = new List<string>();

        [JsonPropertyName("leadershipSkills")]
        public LeadershipSkills LeadershipSkills { get; set; }

        [JsonPropertyName("securityStamp")]
        public string SecurityStamp { get; set; }

        [JsonPropertyName("watermark")]
        public string Watermark { get; set; }

        [JsonPropertyName("loyalty")]
        public string Loyalty { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }
    }

    public class Common
    {
        [JsonPropertyName("balanceColors")]
        public bool BalanceColors { get; set; }

        //[JsonPropertyName("cards")]
        //public Cards Cards { get; set; }

        [JsonPropertyName("foil")]
        public bool Foil { get; set; }

        [JsonPropertyName("totalWeight")]
        public int TotalWeight { get; set; }
    }

    public class Contents
    {
        [JsonPropertyName("common")]
        public int Common { get; set; }

        [JsonPropertyName("rareMythic")]
        public int RareMythic { get; set; }

        [JsonPropertyName("uncommon")]
        public int Uncommon { get; set; }

        [JsonPropertyName("basic")]
        public int Basic { get; set; }

        [JsonPropertyName("foil")]
        public int? Foil { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("baseSetSize")]
        public int BaseSetSize { get; set; }

        [JsonPropertyName("booster")]
        public Booster Booster { get; set; }

        [JsonPropertyName("cards")]
        public List<Card> Cards { get; } = new List<Card>();

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("isFoilOnly")]
        public bool IsFoilOnly { get; set; }

        [JsonPropertyName("isOnlineOnly")]
        public bool IsOnlineOnly { get; set; }

        [JsonPropertyName("keyruneCode")]
        public string KeyruneCode { get; set; }

        [JsonPropertyName("languages")]
        public List<string> Languages { get; } = new List<string>();

        [JsonPropertyName("mcmId")]
        public int McmId { get; set; }

        [JsonPropertyName("mcmIdExtras")]
        public int McmIdExtras { get; set; }

        [JsonPropertyName("mcmName")]
        public string McmName { get; set; }

        [JsonPropertyName("mtgoCode")]
        public string MtgoCode { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("sealedProduct")]
        public List<SealedProduct> SealedProduct { get; } = new List<SealedProduct>();

        [JsonPropertyName("tcgplayerGroupId")]
        public int TcgplayerGroupId { get; set; }

        [JsonPropertyName("tokenSetCode")]
        public string TokenSetCode { get; set; }

        [JsonPropertyName("tokens")]
        public List<Token> Tokens { get; } = new List<Token>();

        [JsonPropertyName("totalSetSize")]
        public int TotalSetSize { get; set; }

        [JsonPropertyName("translations")]
        public Translations Translations { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class Default
    {
        [JsonPropertyName("boosters")]
        public List<Booster> Boosters { get; } = new List<Booster>();

        [JsonPropertyName("boostersTotalWeight")]
        public int BoostersTotalWeight { get; set; }

        [JsonPropertyName("sheets")]
        public Sheets Sheets { get; set; }
    }

    public class Foil
    {
        //[JsonPropertyName("cards")]
        //public Cards Cards { get; set; }

        //[JsonPropertyName("foil")]
       // public bool Foil { get; set; }

        [JsonPropertyName("totalWeight")]
        public int TotalWeight { get; set; }
    }

    public class Identifiers
    {
        [JsonPropertyName("cardKingdomFoilId")]
        public string CardKingdomFoilId { get; set; }

        [JsonPropertyName("cardKingdomId")]
        public string CardKingdomId { get; set; }

        [JsonPropertyName("mcmId")]
        public string McmId { get; set; }

        [JsonPropertyName("mcmMetaId")]
        public string McmMetaId { get; set; }

        [JsonPropertyName("mtgjsonV4Id")]
        public string MtgjsonV4Id { get; set; }

        [JsonPropertyName("mtgoId")]
        public string MtgoId { get; set; }

        [JsonPropertyName("scryfallId")]
        public string ScryfallId { get; set; }

        [JsonPropertyName("scryfallIllustrationId")]
        public string ScryfallIllustrationId { get; set; }

        [JsonPropertyName("scryfallOracleId")]
        public string ScryfallOracleId { get; set; }

        [JsonPropertyName("tcgplayerProductId")]
        public string TcgplayerProductId { get; set; }
    }

    public class LeadershipSkills
    {
        [JsonPropertyName("brawl")]
        public bool Brawl { get; set; }

        [JsonPropertyName("commander")]
        public bool Commander { get; set; }

        [JsonPropertyName("oathbreaker")]
        public bool Oathbreaker { get; set; }
    }

    public class Legalities
    {
        [JsonPropertyName("brawl")]
        public string Brawl { get; set; }

        [JsonPropertyName("commander")]
        public string Commander { get; set; }

        [JsonPropertyName("duel")]
        public string Duel { get; set; }

        [JsonPropertyName("explorer")]
        public string Explorer { get; set; }

        [JsonPropertyName("future")]
        public string Future { get; set; }

        [JsonPropertyName("gladiator")]
        public string Gladiator { get; set; }

        [JsonPropertyName("historic")]
        public string Historic { get; set; }

        [JsonPropertyName("historicbrawl")]
        public string Historicbrawl { get; set; }

        [JsonPropertyName("legacy")]
        public string Legacy { get; set; }

        [JsonPropertyName("modern")]
        public string Modern { get; set; }

        [JsonPropertyName("pioneer")]
        public string Pioneer { get; set; }

        [JsonPropertyName("standard")]
        public string Standard { get; set; }

        [JsonPropertyName("vintage")]
        public string Vintage { get; set; }

        [JsonPropertyName("pauper")]
        public string Pauper { get; set; }
    }

    public class Meta
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }

    public class PurchaseUrls
    {
        [JsonPropertyName("cardKingdom")]
        public string CardKingdom { get; set; }

        [JsonPropertyName("cardKingdomFoil")]
        public string CardKingdomFoil { get; set; }

        [JsonPropertyName("cardmarket")]
        public string Cardmarket { get; set; }

        [JsonPropertyName("tcgplayer")]
        public string Tcgplayer { get; set; }
    }

    public class RareMythic
    {
        //[JsonPropertyName("cards")]
        //public Cards Cards { get; set; }

        [JsonPropertyName("foil")]
        public bool Foil { get; set; }

        [JsonPropertyName("totalWeight")]
        public int TotalWeight { get; set; }
    }

    public class RelatedCards
    {
        [JsonPropertyName("reverseRelated")]
        public List<string> ReverseRelated { get; } = new List<string>();
    }

    public class Root
    {
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public class SealedProduct
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("identifiers")]
        public Identifiers Identifiers { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("purchaseUrls")]
        public PurchaseUrls PurchaseUrls { get; set; }

        [JsonPropertyName("releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("subtype")]
        public string Subtype { get; set; }

        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        [JsonPropertyName("productSize")]
        public int? ProductSize { get; set; }
    }

    public class Sheets
    {
        [JsonPropertyName("common")]
        public Common Common { get; set; }

        [JsonPropertyName("rareMythic")]
        public RareMythic RareMythic { get; set; }

        [JsonPropertyName("uncommon")]
        public Uncommon Uncommon { get; set; }

        [JsonPropertyName("basic")]
        public Basic Basic { get; set; }

        [JsonPropertyName("foil")]
        public Foil Foil { get; set; }
    }

    public class Token
    {
        [JsonPropertyName("artist")]
        public string Artist { get; set; }

        [JsonPropertyName("availability")]
        public List<string> Availability { get; } = new List<string>();

        [JsonPropertyName("borderColor")]
        public string BorderColor { get; set; }

        [JsonPropertyName("colorIdentity")]
        public List<string> ColorIdentity { get; } = new List<string>();

        [JsonPropertyName("colors")]
        public List<string> Colors { get; } = new List<string>();

        [JsonPropertyName("finishes")]
        public List<string> Finishes { get; } = new List<string>();

        [JsonPropertyName("frameVersion")]
        public string FrameVersion { get; set; }

        [JsonPropertyName("hasFoil")]
        public bool HasFoil { get; set; }

        [JsonPropertyName("hasNonFoil")]
        public bool HasNonFoil { get; set; }

        [JsonPropertyName("identifiers")]
        public Identifiers Identifiers { get; set; }

        [JsonPropertyName("isReprint")]
        public bool IsReprint { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("layout")]
        public string Layout { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("power")]
        public string Power { get; set; }

        [JsonPropertyName("relatedCards")]
        public RelatedCards RelatedCards { get; set; }

        [JsonPropertyName("reverseRelated")]
        public List<string> ReverseRelated { get; } = new List<string>();

        [JsonPropertyName("setCode")]
        public string SetCode { get; set; }

        [JsonPropertyName("subtypes")]
        public List<string> Subtypes { get; } = new List<string>();

        [JsonPropertyName("supertypes")]
        public List<string> Supertypes { get; } = new List<string>();

        [JsonPropertyName("toughness")]
        public string Toughness { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("types")]
        public List<string> Types { get; } = new List<string>();

        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        [JsonPropertyName("keywords")]
        public List<string> Keywords { get; } = new List<string>();

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("frameEffects")]
        public List<string> FrameEffects { get; } = new List<string>();
    }

    public class Translations
    {
        [JsonPropertyName("Chinese Simplified")]
        public object ChineseSimplified { get; set; }

        [JsonPropertyName("Chinese Traditional")]
        public object ChineseTraditional { get; set; }

        [JsonPropertyName("French")]
        public string French { get; set; }

        [JsonPropertyName("German")]
        public string German { get; set; }

        [JsonPropertyName("Italian")]
        public string Italian { get; set; }

        [JsonPropertyName("Japanese")]
        public object Japanese { get; set; }

        [JsonPropertyName("Korean")]
        public object Korean { get; set; }

        [JsonPropertyName("Portuguese (Brazil)")]
        public object PortugueseBrazil { get; set; }

        [JsonPropertyName("Russian")]
        public object Russian { get; set; }

        [JsonPropertyName("Spanish")]
        public string Spanish { get; set; }
    }

    public class Uncommon
    {
        //[JsonPropertyName("cards")]
        //public Cards Cards { get; set; }

        [JsonPropertyName("foil")]
        public bool Foil { get; set; }

        [JsonPropertyName("totalWeight")]
        public int TotalWeight { get; set; }
    }


}
