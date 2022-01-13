namespace DrinkSite.Core;

public record LiquerDto([Required, StringLength(50)] string Type);