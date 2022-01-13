namespace DrinkSite.Core;

public record CocktailCreateDto([Required, StringLength(50)] string Name, Method Method, Glass Glass, [Required] ISet<int> Uses, int? Garnish);
public record CocktailInfoDto(int Id, [Required, StringLength(50)] string Name, Method Method);
public record CocktailDetailsDto(int Id, [Required, StringLength(50)] string Name, Method Method, Glass Glass, [Required] ISet<int> Uses, int? Garnish) : CocktailInfoDto(Id, Name, Method);