namespace DrinkSite.Core;

public record SpiritDto([Range(0, 100)] double Volume, [StringLength(50)] string Brand);