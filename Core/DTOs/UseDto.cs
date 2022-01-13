namespace DrinkSite.Core;

public record UseCreateDto(IngredientDto Ingredient, int Amount, Messurement Messurement);
public record UseDto(int Id, IngredientDto Ingredient, int Amount, Messurement Messurement) : UseCreateDto(Ingredient, Amount, Messurement);