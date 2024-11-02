namespace AlzaApp.Domain.DataTransferObjects;

public sealed record ProductDto
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required Uri ImgUri { get; init; }
    public required decimal Price { get; init; }
    public string Description { get; init; } = string.Empty;
}