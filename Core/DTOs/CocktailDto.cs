namespace DrinkSite.Core;

public record CocktailCreateDto([Required, StringLength(50)] string Name, Method Method, Glass Glass, [Required] ISet<UseDto> Ingredients, [Required] ISet<UseDto> Garnish);
public record CocktailDto(int Id, [Required, StringLength(50)] string Name, Method Method, Glass Glass);
public record CocktailDetailsDto(int Id, [Required, StringLength(50)] string Name, Method Method, Glass Glass, [Required] ISet<UseDto> Ingredients, [Required] ISet<UseDto> Garnish) : CocktailDto(Id, Name, Method, Glass);