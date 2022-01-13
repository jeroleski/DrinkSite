namespace DrinkSite.Core;

public interface IIngredientRepository
{
    Task<(Status, IngredientDto)> CreateAsync(IngredientCreateDto ingredient);
    Task<IngredientDto?> ReadAsync(int ingredientId);
    Task<IReadOnlyCollection<IngredientDto>> ReadAsync();
    Task<Status> UpdateAsync(IngredientDto ingredient);
    Task<Status> DeleteAsync(int ingredientId);
}