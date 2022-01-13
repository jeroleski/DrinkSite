namespace DrinkSite.Infrastructure;

public class Ingredient
{
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }
}