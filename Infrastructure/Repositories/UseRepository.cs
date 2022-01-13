namespace DrinkSite.Infrastructure;

public class UseRepository : IUseRepository
{
    private readonly IDrinkContext context;

    public UseRepository(IDrinkContext _context)
    {
        context = _context;
    }

    public async Task<(Status, UseDto)> CreateAsync(UseCreateDto use)
    {
        var ingredient = await GetIngredientAsync(use.Ingredient);
        if (ingredient == null) return (BadRequest, new UseDto(
            -1, 
            use.Ingredient, 
            use.Amount, 
            use.Messurement));

        var entity = new Use(ingredient)
            {Amount = use.Amount,
            Messurement = use.Messurement};
        context.Uses.Add(entity);
        await context.SaveChangesAsync();

        return (Created, new UseDto(
            entity.Id, 
            entity.Ingredient.Id, 
            entity.Amount, 
            entity.Messurement));
    }

    public async Task<UseDto?> ReadAsync(int useId)
    {
        var uses = 
            from u in context.Uses
            where u.Id == useId
            select new UseDto(
                u.Id, 
                u.Ingredient.Id, 
                u.Amount,
                u.Messurement);
        
        return await uses.FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyCollection<UseDto>> ReadAsync()
    {
        return (
            await context.Uses
            .Select(u => new UseDto(
                u.Id, 
                u.Ingredient.Id, 
                u.Amount, 
                u.Messurement))
            .ToListAsync())
            .AsReadOnly();
    }

    public async Task<Status> UpdateAsync(UseDto use)
    {
        var entity = await context.Uses.Include(u => u.Ingredient).FirstOrDefaultAsync(u => u.Id == use.Id);
        if (entity == null) return NotFound;

        var ingredient = await GetIngredientAsync(use.Ingredient);
        if (ingredient == null) return BadRequest;

        entity.Ingredient = ingredient;
        entity.Amount = use.Amount;
        entity.Messurement = use.Messurement;
        await context.SaveChangesAsync();

        return Updated;
    }

    public async Task<Status> DeleteAsync(int useId)
    {
        var entity = await context.Uses.FindAsync(useId);
        if (entity == null) return NotFound;

        context.Uses.Remove(entity);
        await context.SaveChangesAsync();

        return Deleted;
    }

    private async Task<Ingredient?> GetIngredientAsync(int ingredientId)
    {
        var entity = await context.Ingredients.FirstOrDefaultAsync(i => i.Id == ingredientId);
        return entity == null ? null : new Ingredient(entity.Name);
    }
}