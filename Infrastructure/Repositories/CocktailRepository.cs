namespace DrinkSite.Infrastructure;

public class CocktailRepository : ICocktailRepository
{
    private readonly IDrinkContext context;

    public CocktailRepository(IDrinkContext _context)
    {
        context = _context;
    }

    public async Task<(Status, CocktailDetailsDto)> CreateAsunc(CocktailCreateDto cocktail)
    {
        var conflict = 
            await context.Cocktails
            .Where(c => c.Name == cocktail.Name)
            .Select(c => new CocktailDetailsDto(
                c.Id, 
                c.Name, 
                c.Method, 
                c.Glass, 
                c.Uses.Select(u => u.Id).ToHashSet(), 
                c.Garnish == null ? null : c.Garnish.Id))
            .FirstOrDefaultAsync();
        if (conflict != null) return (Conflict, conflict);

        var entity = new Cocktail(cocktail.Name)
        {
            Method = cocktail.Method,
            Glass = cocktail.Glass,
            Uses = await GetUsesAsync(cocktail.Uses),
            Garnish = await GetUseAsync(cocktail.Garnish)
        };
        context.Cocktails.Add(entity);
        await context.SaveChangesAsync();

        return (Created, new CocktailDetailsDto(
            entity.Id, 
            entity.Name, 
            entity.Method, 
            entity.Glass, 
            entity.Uses.Select(u => u.Id).ToHashSet(), 
            entity.Garnish == null ? null : entity.Garnish.Id));
    }

    public async Task<CocktailDetailsDto?> ReadAsync(int cocktailId)
    {
        var cocktails = 
            from c in context.Cocktails
            where c.Id == cocktailId
            select new CocktailDetailsDto(
                c.Id, 
                c.Name, 
                c.Method, 
                c.Glass, 
                c.Uses.Select(u => u.Id).ToHashSet(), 
                c.Garnish == null ? null : c.Garnish.Id);

        return await cocktails.FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyCollection<CocktailInfoDto>> ReadAsync()
    {
        return (
            await context.Cocktails
            .Select(c => new CocktailInfoDto(c.Id, c.Name, c.Method))
            .ToListAsync())
            .AsReadOnly();
    }

    public async Task<Status> UpdateAsync(CocktailDetailsDto cocktail)
    {
        var conflict = 
            await context.Cocktails
            .Where(c => c.Id != cocktail.Id)
            .Where(c => c.Name == cocktail.Name)
            .Select(c => new CocktailInfoDto(c.Id, c.Name, c.Method))
            .AnyAsync();
        if (conflict) return Conflict;
        //TODO also check for relations to new uses

        var entity = await context.Cocktails.FindAsync(cocktail.Id);
        if (entity == null) return NotFound;

        entity.Name = cocktail.Name;
        entity.Method = cocktail.Method;
        entity.Glass = cocktail.Glass;
        entity.Uses = await GetUsesAsync(cocktail.Uses);
        entity.Garnish = await GetUseAsync(cocktail.Garnish);
        await context.SaveChangesAsync();

        return Updated;
    }

    public async Task<Status> DeleteAsync(int cocktailId)
    {
        var entity = 
            await context.Cocktails
            .Include(c => c.Uses)
            .FirstOrDefaultAsync(c => c.Id == cocktailId);
        if (entity == null) return NotFound;
        if (entity.Uses.Any()) return Conflict;

        context.Cocktails.Remove(entity);
        await context.SaveChangesAsync();

        return Deleted;
    }

    private async Task<ISet<Use>> GetUsesAsync(IEnumerable<int> uses)
    {
        var existing = new HashSet<Use>();
        foreach (var useId in uses)
        {   
            var entity = await context.Uses.FindAsync(useId);
            if (entity != null) {
                existing.Add(
                    new Use(entity.Ingredient) {
                        Id = entity.Id, 
                        Amount = entity.Amount, 
                        Messurement = entity.Messurement});
            }
        }
        return existing;
    }

    private async Task<Use?> GetUseAsync(int? useId)
    {
        if (useId == null) return null;
        var entity = await context.Uses.FirstOrDefaultAsync(u => u.Id == useId);
        return entity == null ? null : new Use(entity.Ingredient) {Id = entity.Id, Amount = entity.Amount, Messurement = entity.Messurement};
    }
}