namespace Core;

public record SpiritDto([Range(0, 100)] double volume, [Required, StringLength(50)] string brand);