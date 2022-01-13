namespace DrinkSite.Core;

public record CocktailCreateDto([Required, StringLength(50)] string Name, Method Method, Glass Glass, [Required] ISet<UseDto> Ingredients, UseDto Garnish);
public record CocktailInfoDto(int Id, [Required, StringLength(50)] string Name, Method Method, Glass Glass);
public record CocktailDetailsDto(int Id, [Required, StringLength(50)] string Name, Method Method, Glass Glass, [Required] ISet<UseDto> Ingredients, UseDto Garnish) : CocktailInfoDto(Id, Name, Method, Glass);