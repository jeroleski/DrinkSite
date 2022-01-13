namespace Infrastructure;

public abstract class Spirit : Ingredient
{
    [Range(0, 100)]
    public double volume { get; set; }

    [StringLength(50)]
    public string? brand { get; set; }
}