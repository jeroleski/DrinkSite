namespace DrinkSite.Core;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Messurement
{
    Ml,
    Dashes,
    Pieces,
}