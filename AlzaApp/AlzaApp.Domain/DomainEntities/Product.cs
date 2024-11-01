namespace AlzaApp.Domain.DomainEntities;

public sealed record Product
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required Uri ImgUri { get; init; }
    public required decimal Price { get; init; }
    public string Description { get; init; } = string.Empty;
    public DateTimeOffset UpdatedAt { get; init; } = DateTimeOffset.MinValue;
    
    public static Product Empty => new()
    {
        Id = -1,
        Name = string.Empty,
        ImgUri = new Uri("about:blank"),
        Price = 0.0m,
        Description = string.Empty,
        UpdatedAt = DateTimeOffset.MinValue
    };
}