namespace DrinkSite.Infrastructure;

public class Mixer : Ingredient
{
    public bool Carbonated { get; set; }

    public Mixer(string name) : base(name) {}
}