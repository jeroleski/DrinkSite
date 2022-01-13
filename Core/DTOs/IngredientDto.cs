namespace DrinkSite.Core;

public record IngredientCreateDto([Required, StringLength(50)] string Name);
public record IngredientDto(int Id, [Required, StringLength(50)] string Name) : IngredientCreateDto(Name);