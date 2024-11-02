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
        await DbContext.Products.AddRangeAsync(MockedData.ProductsDo);
        await DbContext.SaveChangesAsync();

        // Act
        var result = await ProductsRepository.GetAllProductsAsync();

        // Assert
        Assert.That(result.IsSuccess, Is.True);
        
        var products = result.Value.ToList();
        
        Assert.That(products.Count, Is.EqualTo(MockedData.ProductsDo.Count));
        Assert.That(products.First().Id, Is.EqualTo(MockedData.ProductsDo.First().Id));
        Assert.That(products.Last().Id, Is.EqualTo(MockedData.ProductsDo.Last().Id));
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
        DbContext.Products.AddRange(MockedData.ProductsDo);
        await DbContext.SaveChangesAsync();

        const int page = 1;
        const int pageSize = 5;

        // Act
        var result = await ProductsRepository.GetAllProductsPaginatedAsync(page, pageSize);

        // Assert
        Assert.That(result.IsSuccess, Is.True);
        
        var products = result.Value.ToList();
        
        Assert.That(products.Count, Is.EqualTo(pageSize));
        Assert.That(products.Last().Id, Is.EqualTo(MockedData.ProductsDo[pageSize - 1].Id));
    }
    
    [Test]
    public async Task GetAllProductsPaginatedAsync_ReturnsCorrectPageOfProducts_DefaultPageSize()
    {
        // Arrange
        DbContext.Products.AddRange(MockedData.ProductsDo);
        await DbContext.SaveChangesAsync();

        const int page = 1;

        // Act
        var result = await ProductsRepository.GetAllProductsPaginatedAsync(page);

        // Assert
        Assert.That(result.IsSuccess, Is.True);
        
        var products = result.Value.ToList();
        
        Assert.That(products.Count, Is.EqualTo(10));
        Assert.That(products.Last().Id, Is.EqualTo(MockedData.ProductsDo[9].Id));
    }

    [Test]
    public async Task GetAllProductsPaginatedAsync_ReturnsFailure_WhenPageIsOutOfRange()
    {
        // Arrange
        DbContext.Products.AddRange(MockedData.ProductsDo);
        await DbContext.SaveChangesAsync();

        const int page = 2;
        var pageSize = MockedData.ProductsDo.Count;

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
        await DbContext.Products.AddRangeAsync(MockedData.ProductsDo);
        await DbContext.SaveChangesAsync();

        const int productId = 3;

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
        await DbContext.Products.AddRangeAsync(MockedData.ProductsDo);
        await DbContext.SaveChangesAsync();

        var productId = MockedData.ProductsDo.Count + 1;

        // Act
        var result = await ProductsRepository.GetProductByIdAsync(productId);

        // Assert
        Assert.That(result.IsFailed, Is.True);
    }

    [Test]
    public async Task GetProductByIdAsync_ReturnsFailure_WhenIdIsNegative()
    {
        // Arrange
        await DbContext.Products.AddRangeAsync(MockedData.ProductsDo);
        await DbContext.SaveChangesAsync();

        const int productId = -1;

        // Act
        var result = await ProductsRepository.GetProductByIdAsync(productId);

        // Assert
        Assert.That(result.IsFailed, Is.True);
    }

    [Test]
    public async Task UpdateDescriptionAsync_UpdatesDescription_WhenProductExists()
    {
        // Arrange
        await DbContext.Products.AddRangeAsync(MockedData.ProductsDo);
        await DbContext.SaveChangesAsync();

        const int productId = 3;
        const string newDescription = "New Description";

        // Act
        var result = await ProductsRepository.UpdateDescriptionAsync(productId, newDescription);

        // Assert
        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Value.Description, Is.EqualTo(newDescription));
        Assert.That(result.Value.UpdatedAt, Is.Not.EqualTo(MockedData.ProductsDo[productId - 1].UpdatedAt));
    }

    [Test]
    public async Task UpdateDescriptionAsync_ReturnsFailure_WhenProductDoesNotExist()
    {
        // Arrange
        await DbContext.Products.AddRangeAsync(MockedData.ProductsDo);
        await DbContext.SaveChangesAsync();

        var productId = MockedData.ProductsDo.Count + 1;
        const string newDescription = "New Description";

        // Act
        var result = await ProductsRepository.UpdateDescriptionAsync(productId, newDescription);

        // Assert
        Assert.That(result.IsFailed, Is.True);
    }

    [Test]
    public async Task UpdateDescriptionAsync_ReturnsFailure_WhenIdIsNegative()
    {
        // Arrange
        await DbContext.Products.AddRangeAsync(MockedData.ProductsDo);
        await DbContext.SaveChangesAsync();

        const int productId = -1;
        const string newDescription = "New Description";

        // Act
        var result = await ProductsRepository.UpdateDescriptionAsync(productId, newDescription);

        // Assert
        Assert.That(result.IsFailed, Is.True);
    }
}