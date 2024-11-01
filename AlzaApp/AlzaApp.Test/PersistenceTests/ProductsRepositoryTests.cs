using AlzaApp.Domain.DomainEntities;
using AlzaApp.Domain.Interfaces;
using AlzaApp.Test.Mocks.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace AlzaApp.Test.PersistenceTests;

internal sealed class ProductsRepositoryTests : BaseRepositoryTest
{
    private IProductsRepository ProductsRepository { get; set; } = null!;

    protected override void SetUp()
    {
        ProductsRepository = ServiceProvider.GetRequiredService<IProductsRepository>();
    }

    [Test]
    public async Task GetAllProductsAsync_ReturnsAllProducts()
    {
        // Arrange
        await DbContext.Products.AddRangeAsync(MockedData.Products);
        await DbContext.SaveChangesAsync();
        
        // Act
        var result = (await ProductsRepository.GetAllProductsAsync()).ToList();

        // Assert
        Assert.That(result.Count, Is.EqualTo(MockedData.Products.Count));
        
        Assert.That(result.First().Id, Is.EqualTo(MockedData.Products.First().Id));
        Assert.That(result.Last().Id, Is.EqualTo(MockedData.Products.Last().Id));
    }

    [Test]
    public async Task GetAllProductsAsync_ReturnsEmpty_WhenNoProductsExist()
    {
        // Act
        var result = await ProductsRepository.GetAllProductsAsync();
    
        // Assert
        Assert.That(result, Is.Empty);
    }
    
    [Test]
    public async Task GetAllProductsPaginatedAsync_ReturnsCorrectPageOfProducts()
    {
        // Arrange
        DbContext.Products.AddRange(MockedData.Products);
        await DbContext.SaveChangesAsync();
        
        var page = 1;
        var pageSize = 5;

        // Act
        var result = (await ProductsRepository.GetAllProductsPaginatedAsync(page, pageSize)).ToList();

        // Assert
        Assert.That(result.Count, Is.EqualTo(pageSize));
        Assert.That(result.Last().Id, Is.EqualTo(MockedData.Products[pageSize - 1].Id));
    }
    
    [Test]
    public async Task GetAllProductsPaginatedAsync_ReturnsCorrectPageOfProducts_DefaultPageSize()
    {
        // Arrange
        DbContext.Products.AddRange(MockedData.Products);
        await DbContext.SaveChangesAsync();
        
        var page = 1;

        // Act
        var result = (await ProductsRepository.GetAllProductsPaginatedAsync(page)).ToList();

        // Assert
        Assert.That(result.Count, Is.EqualTo(10));
        Assert.That(result.Last().Id, Is.EqualTo(MockedData.Products[9].Id));
    }

    [Test]
    public async Task GetAllProductsPaginatedAsync_ReturnsEmpty_WhenPageIsOutOfRange()
    {
        // Arrange
        DbContext.Products.AddRange(MockedData.Products);
        await DbContext.SaveChangesAsync();
        
        var page = 2;
        var pageSize = MockedData.Products.Count;

        // Act
        var result = await ProductsRepository.GetAllProductsPaginatedAsync(page, pageSize);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public async Task GetAllProductsPaginatedAsync_ReturnsEmpty_WhenNoProductsExist()
    {
        // Act
        var result = await ProductsRepository.GetAllProductsPaginatedAsync(1);
    
        // Assert
        Assert.That(result, Is.Empty);
    }
    
    [Test]
    public async Task GetProductByIdAsync_ReturnsProduct_WhenProductExists()
    {
        // Arrange
        await DbContext.Products.AddRangeAsync(MockedData.Products);
        await DbContext.SaveChangesAsync();
        
        var productId = 3;

        // Act
        var result = await ProductsRepository.GetProductByIdAsync(productId);

        // Assert
        Assert.That(result.Id, Is.EqualTo(productId));
    }

    [Test]
    public async Task GetProductByIdAsync_ReturnsEmptyProduct_WhenProductDoesNotExist()
    {
        // Arrange
        await DbContext.Products.AddRangeAsync(MockedData.Products);
        await DbContext.SaveChangesAsync();
        
        var productId = MockedData.Products.Count + 1;

        // Act
        var result = await ProductsRepository.GetProductByIdAsync(productId);

        // Assert
        Assert.That(result, Is.EqualTo(Product.Empty));
    }

    [Test]
    public async Task GetProductByIdAsync_ReturnsEmptyProduct_WhenIdIsNegative()
    {
        // Arrange
        await DbContext.Products.AddRangeAsync(MockedData.Products);
        await DbContext.SaveChangesAsync();
        
        var productId = -1;

        // Act
        var result = await ProductsRepository.GetProductByIdAsync(productId);

        // Assert
        Assert.That(result, Is.EqualTo(Product.Empty));
    }
    
    [Test]
    public async Task UpdateDescriptionAsync_UpdatesDescription_WhenProductExists()
    {
        // Arrange
        await DbContext.Products.AddRangeAsync(MockedData.Products);
        await DbContext.SaveChangesAsync();
        
        var productId = 3;
        var newDescription = "New Description";

        // Act
        var result = await ProductsRepository.UpdateDescriptionAsync(productId, newDescription);

        // Assert
        Assert.That(result.Description, Is.EqualTo(newDescription));
        Assert.That(result.UpdatedAt, Is.Not.EqualTo(MockedData.Products[productId - 1].UpdatedAt));
    }

    [Test]
    public async Task UpdateDescriptionAsync_ReturnsEmptyProduct_WhenProductDoesNotExist()
    {
        // Arrange
        await DbContext.Products.AddRangeAsync(MockedData.Products);
        await DbContext.SaveChangesAsync();
        
        var productId = MockedData.Products.Count + 1;
        var newDescription = "New Description";

        // Act
        var result = await ProductsRepository.UpdateDescriptionAsync(productId, newDescription);

        // Assert
        Assert.That(result, Is.EqualTo(Product.Empty));
    }

    [Test]
    public async Task UpdateDescriptionAsync_ReturnsEmptyProduct_WhenIdIsNegative()
    {
        // Arrange
        await DbContext.Products.AddRangeAsync(MockedData.Products);
        await DbContext.SaveChangesAsync();
        
        var productId = -1;
        var newDescription = "New Description";

        // Act
        var result = await ProductsRepository.UpdateDescriptionAsync(productId, newDescription);

        // Assert
        Assert.That(result, Is.EqualTo(Product.Empty));
    }
}