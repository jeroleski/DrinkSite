namespace Core;

public record CocktailCreateDto([Required, StringLength(50)] string name, Method method, Glass glass, [Required] ISet<UseDto> ingredients, [Required] ISet<UseDto> garnish);
public record CocktailDto(int id, [Required, StringLength(50)] string name, Method method, Glass glass);
public record CocktailDetailsDto(int id, [Required, StringLength(50)] string name, Method method, Glass glass, [Required] ISet<UseDto> ingredients, [Required] ISet<UseDto> garnish) : CocktailDto(id, name, method, glass);