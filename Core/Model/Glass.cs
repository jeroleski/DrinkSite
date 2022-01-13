namespace DrinkSite.Core;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Glass
{
    Rock,
    Highball,
    Martini,
    Wine,
    Champagne,
    Horricane,
    Shot,
}