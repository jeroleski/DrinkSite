namespace Infrastructure;

public class Cocktail
{
    public int id { get; set; }

    [StringLength(50)]
    public string? name { get; set; }

    public Method method { get; set; }
    public Glass glass { get; set; }
    public ICollection<Use> uses { get; set; } = new List<Use>();
    public ICollection<Use> garnish { get; set; } = new List<Use>();
}