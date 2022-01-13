namespace Infrastructure;

public class Ingredient
{
    public int id { get; set; }

    [StringLength(50)]
    public string? name { get; set; }
}