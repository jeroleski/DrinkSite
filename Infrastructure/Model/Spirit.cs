namespace DrinkSite.Infrastructure;

public abstract class Spirit : Ingredient
{
    [Range(0, 100)]
    public double Volume { get; set; }

    [StringLength(50)]
    public string? Brand { get; set; }
}