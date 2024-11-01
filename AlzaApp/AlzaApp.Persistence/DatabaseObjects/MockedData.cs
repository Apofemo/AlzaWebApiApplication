namespace AlzaApp.Persistence.DatabaseObjects;

internal static class MockedData
{
    internal static IEnumerable<ProductDo> GetMockedProducts()
    {
        return new List<ProductDo>
        {
            new()
            {
                Id = 1,
                Name = "Product 1",
                ImgUri = "photoPlaceholder1.jpg",
                Price = 100,
                Description = "Description of product 1",
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.MinValue
            },
            new()
            {
                Id = 2,
                Name = "Product 2",
                ImgUri = "photoPlaceholder2.jpg",
                Price = 200,
                Description = "Description of product 2",
                CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-1),
                UpdatedAt = DateTimeOffset.MinValue
            },
            new()
            {
                Id = 3,
                Name = "Product 3",
                ImgUri = "photoPlaceholder3.jpg",
                Price = 300,
                Description = "Description of product 3",
                CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-2),
                UpdatedAt = DateTimeOffset.MinValue
            },
            new()
            {
                Id = 4,
                Name = "Product 4",
                ImgUri = "photoPlaceholder4.jpg",
                Price = 400,
                Description = "Description of product 4",
                CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-3),
                UpdatedAt = DateTimeOffset.MinValue
            },
            new()
            {
                Id = 5,
                Name = "Product 5",
                ImgUri = "photoPlaceholder5.jpg",
                Price = 500,
                Description = "Description of product 5",
                CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-4),
                UpdatedAt = DateTimeOffset.MinValue
            }
        };
    }
}