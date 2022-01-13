namespace DrinkSite.Infrastructure;

public class IngredientRepository : IIngredientRepository
{
    private readonly IDrinkContext context;

    public IngredientRepository(IDrinkContext _context)
    {
        context = _context;
    }

    public async Task<(Status, IngredientDto)> CreateAsync(IngredientCreateDto ingredient)
    {
        var conflict = 
            await context.Ingredients
            .Where(i => i.Name == ingredient.Name)
            .Select(c => new IngredientDto(c.Id, c.Name))
            .FirstOrDefaultAsync();
        if (conflict != null) return (Conflict, conflict);

        var entity = new Ingredient(ingredient.Name);
        context.Ingredients.Add(entity);
        await context.SaveChangesAsync();

        return (Created, new IngredientDto(entity.Id, entity.Name));
    }

    public async Task<IngredientDto?> ReadAsync(int ingredientId)
    {
        var ingredients = 
            from i in context.Ingredients
            where i.Id == ingredientId
            select new IngredientDto(i.Id, i.Name);

        return await ingredients.FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyCollection<IngredientDto>> ReadAsync()
    {
        return (
            await context.Ingredients
            .Select(i => new IngredientDto(i.Id, i.Name))
            .ToListAsync())
            .AsReadOnly();
    }

    public async Task<Status> UpdateAsync(IngredientDto ingredient)
    {
        var conflict = 
            await context.Ingredients
            .Where(i => i.Id != ingredient.Id)
            .Where(i => i.Name == ingredient.Name)
            .Select(i => new IngredientDto(i.Id, i.Name))
            .AnyAsync();
        if (conflict) return Conflict;
        //TODO also check for relations to uses

        var entity = await context.Ingredients.FindAsync(ingredient.Id);
        if (entity == null) return NotFound;

        entity.Name = ingredient.Name;
        await context.SaveChangesAsync();

        return Updated;
    }

    public async Task<Status> DeleteAsync(int ingredientId)
    {
        var entity = await context.Ingredients.FindAsync(ingredientId);
        if (entity == null) return NotFound;
        //TODO must not delete an ingredient uses by a use
        context.Ingredients.Remove(entity);
        await context.SaveChangesAsync();

        return Deleted;
    }
}