namespace DrinkSite.Infrastructure;

public class Use
{
    public int Id { get; set; }
    public Ingredient Ingredient { get; set; }
    public int Amount { get; set; }
    public Messurement Messurement { get; set; }

    public Use(Ingredient ingredient)
    {
        Ingredient = ingredient;
    }
}