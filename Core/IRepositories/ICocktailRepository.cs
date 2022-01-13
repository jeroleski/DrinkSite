namespace DrinkSite.Core;

public interface ICocktailRepository
{
    Task<(Status, CocktailDetailsDto)> CreateAsunc(CocktailCreateDto cocktail);
    Task<CocktailDetailsDto?> ReadAsync(int cocktailId);
    Task<IReadOnlyCollection<CocktailInfoDto>> ReadAsync();
    Task<Status> UpdateAsync(CocktailDetailsDto cocktail);
    Task<Status> DeleteAsync(int cocktailId);
}