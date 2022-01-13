namespace DrinkSite.Infrastructure;

public class Liquer : Spirit
{
    [StringLength(50)]
    public string? Type { get; set; }
}