using AlzaApp.Core.Interfaces;
using AlzaApp.Domain.DataTransferObjects;
using AlzaApp.Domain.DomainEntities.Errors.Core;
using AlzaApp.Test.Mocks.Core;
using FluentResults;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace AlzaApp.Test.CoreTests;

internal sealed class ProductsServiceTests : BaseCoreTest
{
    private IProductsService ProductsService { get; set; } = null!;

    protected override void SetUp()
    {
        ProductsService = ServiceProvider.GetRequiredService<IProductsService>();
    }
    
    [Test]
    public async Task GetAllProductsAsync_ReturnsAllProducts_WhenProductsExist()
    {
        // Arrange
        ProductsRepositoryMock.Setup(repo => repo.GetAllProductsAsync())
                               .ReturnsAsync(Result.Ok(MockedData.Products));
        
        var productsDto = Mapper.Map<IEnumerable<ProductDto>>(MockedData.Products);
        
        // Act
        var result = await ProductsService.GetAllProductsAsync();
        
        // Assert
        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Value, Is.EquivalentTo(productsDto));
    }
    
    [Test]
    public async Task GetAllProductsAsync_ReturnsFailure_WhenRepositoryFails()
    {
        // Arrange
        ProductsRepositoryMock.Setup(repo => repo.GetAllProductsAsync())
                               .ReturnsAsync(Result.Fail(string.Empty));
    
        // Act
        var result = await ProductsService.GetAllProductsAsync();
        
        // Assert
        Assert.That(result.IsFailed, Is.True);
        Assert.That(result.Errors.Count, Is.EqualTo(1));
    }
    
    [Test]
    public async Task GetAllProductsPaginatedAsync_ReturnsPaginatedProducts_WhenProductsExist()
    {
        // Arrange
        const int page = 1;
        const int pageSize = 5;
        var paginatedProducts = MockedData.Products.Take(pageSize);
        
        ProductsRepositoryMock.Setup(repo => repo.GetAllProductsPaginatedAsync(page, pageSize))
                              .ReturnsAsync(Result.Ok(paginatedProducts));

        var productsDto = Mapper.Map<IEnumerable<ProductDto>>(paginatedProducts);

        // Act
        var result = await ProductsService.GetAllProductsPaginatedAsync(page, pageSize);

        // Assert
        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Value, Is.EquivalentTo(productsDto));
    }

    [Test]
    public async Task GetAllProductsPaginatedAsync_ReturnsFailure_WhenRepositoryFails()
    {
        // Arrange
        const int page = 1;
        const int pageSize = 5;
        
        ProductsRepositoryMock.Setup(repo => repo.GetAllProductsPaginatedAsync(page, pageSize))
                              .ReturnsAsync(Result.Fail(string.Empty));

        // Act
        var result = await ProductsService.GetAllProductsPaginatedAsync(page, pageSize);

        // Assert
        Assert.That(result.IsFailed, Is.True);
        Assert.That(result.Errors.Count, Is.EqualTo(1));
    }

    [Test]
    public async Task GetProductByIdAsync_ReturnsProduct_WhenProductExists()
    {
        // Arrange
        const int productId = 3;
        var product = MockedData.Products.First(p => p.Id == productId);
        
        ProductsRepositoryMock.Setup(repo => repo.GetProductByIdAsync(productId))
                              .ReturnsAsync(Result.Ok(product));

        var productDto = Mapper.Map<ProductDto>(product);

        // Act
        var result = await ProductsService.GetProductByIdAsync(productId);

        // Assert
        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Value, Is.EqualTo(productDto));
    }

    [Test]
    public async Task GetProductByIdAsync_ReturnsFailure_WhenProductDoesNotExist()
    {
        // Arrange
        const int productId = -1;
        
        ProductsRepositoryMock.Setup(repo => repo.GetProductByIdAsync(productId))
                              .ReturnsAsync(Result.Fail(string.Empty));

        // Act
        var result = await ProductsService.GetProductByIdAsync(productId);

        // Assert
        Assert.That(result.IsFailed, Is.True);
        Assert.That(result.Errors.Count, Is.EqualTo(1));
    }

    [Test]
    public async Task UpdateDescriptionAsync_ReturnsUpdatedProduct_WhenProductExists()
    {
        // Arrange
        const int productId = 3;
        const string newDescription = "Updated description";
        var now = DateTimeOffset.UtcNow;
        var product = MockedData.Products.First(p => p.Id == productId) with
        {
            Description = newDescription,
            UpdatedAt = now
        };
        
        ProductsRepositoryMock.Setup(repo => repo.UpdateDescriptionAsync(productId, newDescription))
                              .ReturnsAsync(Result.Ok(product));

        var productDto = Mapper.Map<ProductDto>(product);

        // Act
        var result = await ProductsService.UpdateDescriptionAsync(productId, newDescription);

        // Assert
        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Value, Is.EqualTo(productDto));
    }

    [Test]
    public async Task UpdateDescriptionAsync_ReturnsFailure_WhenProductDoesNotExist()
    {
        // Arrange
        const int productId = -1;
        const string newDescription = "Updated description";
        
        ProductsRepositoryMock.Setup(repo => repo.UpdateDescriptionAsync(productId, newDescription))
                              .ReturnsAsync(Result.Fail(string.Empty));

        // Act
        var result = await ProductsService.UpdateDescriptionAsync(productId, newDescription);

        // Assert
        Assert.That(result.IsFailed, Is.True);
    }

    [Test]
    public async Task UpdateDescriptionAsync_ReturnsFailure_WhenDescriptionIsEmpty()
    {
        // Arrange
        const int productId = 3;
        var newDescription = string.Empty;
        
        ProductsRepositoryMock.Setup(repo => repo.UpdateDescriptionAsync(productId, newDescription))
                              .ReturnsAsync(Result.Fail(string.Empty));

        // Act
        var result = await ProductsService.UpdateDescriptionAsync(productId, newDescription);

        // Assert
        Assert.That(result.IsFailed, Is.True);
        Assert.That(result.Errors.Count, Is.EqualTo(1));
        Assert.That(result.Errors.First(), Is.TypeOf<DescriptionIsEmptyError>());
    }
    
    [Test]
    public async Task UpdateDescriptionAsync_ReturnsFailure_WhenDescriptionIsTooLong()
    {
        // Arrange
        const int productId = 3;
        var newDescription = new string('a', 1001);
        
        ProductsRepositoryMock.Setup(repo => repo.UpdateDescriptionAsync(productId, newDescription))
                              .ReturnsAsync(Result.Fail(string.Empty));

        // Act
        var result = await ProductsService.UpdateDescriptionAsync(productId, newDescription);

        // Assert
        Assert.That(result.IsFailed, Is.True);
        Assert.That(result.Errors.Count, Is.EqualTo(1));
        Assert.That(result.Errors.First(), Is.TypeOf<DescriptionIsTooLongError>());
    }
}