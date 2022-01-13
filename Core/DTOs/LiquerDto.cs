namespace Core;

public record LiquerDto([Required, StringLength(50)] string type);