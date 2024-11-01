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
        var result = await ProductsRepository.GetAllProductsAsync();

        // Assert
        Assert.That(result.IsSuccess, Is.True);
        
        var products = result.Value.ToList();
        
        Assert.That(products.Count, Is.EqualTo(MockedData.Products.Count));
        Assert.That(products.First().Id, Is.EqualTo(MockedData.Products.First().Id));
        Assert.That(products.Last().Id, Is.EqualTo(MockedData.Products.Last().Id));
    }

    [Test]
    public async Task GetAllProductsAsync_ReturnsFailure_WhenNoProductsExist()
    {
        // Act
        var result = await ProductsRepository.GetAllProductsAsync();

        // Assert
        Assert.That(result.IsFailed, Is.True);
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
        var result = await ProductsRepository.GetAllProductsPaginatedAsync(page, pageSize);

        // Assert
        Assert.That(result.IsSuccess, Is.True);
        
        var products = result.Value.ToList();
        
        Assert.That(products.Count, Is.EqualTo(pageSize));
        Assert.That(products.Last().Id, Is.EqualTo(MockedData.Products[pageSize - 1].Id));
    }
    
    [Test]
    public async Task GetAllProductsPaginatedAsync_ReturnsCorrectPageOfProducts_DefaultPageSize()
    {
        // Arrange
        DbContext.Products.AddRange(MockedData.Products);
        await DbContext.SaveChangesAsync();

        var page = 1;

        // Act
        var result = await ProductsRepository.GetAllProductsPaginatedAsync(page);

        // Assert
        Assert.That(result.IsSuccess, Is.True);
        
        var products = result.Value.ToList();
        
        Assert.That(products.Count, Is.EqualTo(10));
        Assert.That(products.Last().Id, Is.EqualTo(MockedData.Products[9].Id));
    }

    [Test]
    public async Task GetAllProductsPaginatedAsync_ReturnsFailure_WhenPageIsOutOfRange()
    {
        // Arrange
        DbContext.Products.AddRange(MockedData.Products);
        await DbContext.SaveChangesAsync();

        var page = 2;
        var pageSize = MockedData.Products.Count;

        // Act
        var result = await ProductsRepository.GetAllProductsPaginatedAsync(page, pageSize);

        // Assert
        Assert.That(result.IsFailed, Is.True);
    }

    [Test]
    public async Task GetAllProductsPaginatedAsync_ReturnsFailure_WhenNoProductsExist()
    {
        // Act
        var result = await ProductsRepository.GetAllProductsPaginatedAsync(1);

        // Assert
        Assert.That(result.IsFailed, Is.True);
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
        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Value.Id, Is.EqualTo(productId));
    }

    [Test]
    public async Task GetProductByIdAsync_ReturnsFailure_WhenProductDoesNotExist()
    {
        // Arrange
        await DbContext.Products.AddRangeAsync(MockedData.Products);
        await DbContext.SaveChangesAsync();

        var productId = MockedData.Products.Count + 1;

        // Act
        var result = await ProductsRepository.GetProductByIdAsync(productId);

        // Assert
        Assert.That(result.IsFailed, Is.True);
    }

    [Test]
    public async Task GetProductByIdAsync_ReturnsFailure_WhenIdIsNegative()
    {
        // Arrange
        await DbContext.Products.AddRangeAsync(MockedData.Products);
        await DbContext.SaveChangesAsync();

        var productId = -1;

        // Act
        var result = await ProductsRepository.GetProductByIdAsync(productId);

        // Assert
        Assert.That(result.IsFailed, Is.True);
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
        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Value.Description, Is.EqualTo(newDescription));
        Assert.That(result.Value.UpdatedAt, Is.Not.EqualTo(MockedData.Products[productId - 1].UpdatedAt));
    }

    [Test]
    public async Task UpdateDescriptionAsync_ReturnsFailure_WhenProductDoesNotExist()
    {
        // Arrange
        await DbContext.Products.AddRangeAsync(MockedData.Products);
        await DbContext.SaveChangesAsync();

        var productId = MockedData.Products.Count + 1;
        var newDescription = "New Description";

        // Act
        var result = await ProductsRepository.UpdateDescriptionAsync(productId, newDescription);

        // Assert
        Assert.That(result.IsFailed, Is.True);
    }

    [Test]
    public async Task UpdateDescriptionAsync_ReturnsFailure_WhenIdIsNegative()
    {
        // Arrange
        await DbContext.Products.AddRangeAsync(MockedData.Products);
        await DbContext.SaveChangesAsync();

        var productId = -1;
        var newDescription = "New Description";

        // Act
        var result = await ProductsRepository.UpdateDescriptionAsync(productId, newDescription);

        // Assert
        Assert.That(result.IsFailed, Is.True);
    }
}