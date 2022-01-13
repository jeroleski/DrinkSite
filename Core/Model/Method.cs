namespace DrinkSite.Core;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Method
{
    Build,
    Shake,
    DryShake,
    Stir,
}