namespace DrinkSite.Core;

public record UseCreateDto([Required] int Ingredient, int Amount, Messurement Messurement);
public record UseDto(int Id, [Required] int Ingredient, int Amount, Messurement Messurement) : UseCreateDto(Ingredient, Amount, Messurement);