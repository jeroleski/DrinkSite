namespace Core;

public record IngredientCreateDto([Required, StringLength(50)] string name);
public record IngredientDto(int id, [Required, StringLength(50)] string name) : IngredientCreateDto(name);