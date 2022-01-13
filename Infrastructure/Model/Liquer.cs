namespace Infrastructure;

public class Liquer : Spirit
{
    [StringLength(50)]
    public string? type { get; set; }
}