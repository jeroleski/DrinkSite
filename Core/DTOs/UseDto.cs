namespace Core;

public record UseCreateDto(IngredientDto ingredient, int amount, Messurement messurement);
public record UseDto(int id, IngredientDto ingredient, int amount, Messurement messurement) : UseCreateDto(ingredient, amount, messurement);