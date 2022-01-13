namespace DrinkSite.Infrastructure;

public class Cocktail
{
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; }

    public Method Method { get; set; }
    public Glass Glass { get; set; }
    public ICollection<Use> Uses { get; set; } = new HashSet<Use>();
    public Use? Garnish { get; set; }

    public Cocktail(string name)
    {
        Name = name;
    }
}