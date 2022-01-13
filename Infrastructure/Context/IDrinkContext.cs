namespace DrinkSite.Infrastructure;

public interface IDrinkContext : IDisposable
{
    DbSet<Cocktail> Cocktails { get; }
    DbSet<Ingredient> Ingredients { get; }
    DbSet<Use> Uses { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}