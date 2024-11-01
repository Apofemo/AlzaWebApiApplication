namespace AlzaApp.Persistence.DatabaseObjects;

internal static class SeedData
{
    internal static List<ProductDo> SeedProducts =>
    [
        new()
        {
            Id = 1,
            Name = "Product 1",
            ImgUri = "https://photoPlaceholder1.jpg",
            Price = 100,
            Description = "Description of product 1",
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.MinValue
        },

        new()
        {
            Id = 2,
            Name = "Product 2",
            ImgUri = "https://photoPlaceholder2.jpg",
            Price = 200,
            Description = "Description of product 2",
            CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-1),
            UpdatedAt = DateTimeOffset.MinValue
        },

        new()
        {
            Id = 3,
            Name = "Product 3",
            ImgUri = "https://photoPlaceholder3.jpg",
            Price = 300,
            Description = "Description of product 3",
            CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-2),
            UpdatedAt = DateTimeOffset.MinValue
        },

        new()
        {
            Id = 4,
            Name = "Product 4",
            ImgUri = "https://photoPlaceholder4.jpg",
            Price = 400,
            Description = "Description of product 4",
            CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-3),
            UpdatedAt = DateTimeOffset.MinValue
        },

        new()
        {
            Id = 5,
            Name = "Product 5",
            ImgUri = "https://photoPlaceholder5.jpg",
            Price = 500,
            Description = "Description of product 5",
            CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-4),
            UpdatedAt = DateTimeOffset.MinValue
        },

        new()
        {
            Id = 6,
            Name = "Product 6",
            ImgUri = "https://photoPlaceholder6.jpg",
            Price = 600,
            Description = "Description of product 6",
            CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-5),
            UpdatedAt = DateTimeOffset.MinValue
        },

        new()
        {
            Id = 7,
            Name = "Product 7",
            ImgUri = "https://photoPlaceholder7.jpg",
            Price = 700,
            Description = "Description of product 7",
            CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-6),
            UpdatedAt = DateTimeOffset.MinValue
        },

        new()
        {
            Id = 8,
            Name = "Product 8",
            ImgUri = "https://photoPlaceholder8.jpg",
            Price = 800,
            Description = "Description of product 8",
            CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-7),
            UpdatedAt = DateTimeOffset.MinValue
        },

        new()
        {
            Id = 9,
            Name = "Product 9",
            ImgUri = "https://photoPlaceholder9.jpg",
            Price = 900,
            Description = "Description of product 9",
            CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-8),
            UpdatedAt = DateTimeOffset.MinValue
        },

        new()
        {
            Id = 10,
            Name = "Product 10",
            ImgUri = "https://photoPlaceholder10.jpg",
            Price = 1000,
            Description = "Description of product 10",
            CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-9),
            UpdatedAt = DateTimeOffset.MinValue
        },

        new()
        {
            Id = 11,
            Name = "Product 11",
            ImgUri = "https://photoPlaceholder11.jpg",
            Price = 1100,
            Description = "Description of product 11",
            CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-10),
            UpdatedAt = DateTimeOffset.MinValue
        },

        new()
        {
            Id = 12,
            Name = "Product 12",
            ImgUri = "https://photoPlaceholder12.jpg",
            Price = 1200,
            Description = "Description of product 12",
            CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-11),
            UpdatedAt = DateTimeOffset.MinValue
        },

        new()
        {
            Id = 13,
            Name = "Product 13",
            ImgUri = "https://photoPlaceholder13.jpg",
            Price = 1300,
            Description = "Description of product 13",
            CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-12),
            UpdatedAt = DateTimeOffset.MinValue
        },

        new()
        {
            Id = 14,
            Name = "Product 14",
            ImgUri = "https://photoPlaceholder14.jpg",
            Price = 1400,
            Description = "Description of product 14",
            CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-13),
            UpdatedAt = DateTimeOffset.MinValue
        },

        new()
        {
            Id = 15,
            Name = "Product 15",
            ImgUri = "https://photoPlaceholder15.jpg",
            Price = 1500,
            Description = "Description of product 15",
            CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-14),
            UpdatedAt = DateTimeOffset.MinValue
        }
    ];
}