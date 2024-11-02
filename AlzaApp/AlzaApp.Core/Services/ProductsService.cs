using AlzaApp.Core.Interfaces;
using AlzaApp.Domain.DataTransferObjects;
using AlzaApp.Domain.Interfaces;
using AutoMapper;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace AlzaApp.Core.Services;

internal sealed class ProductsService(
    IMapper mapper,
    ILogger<ProductsService> logger,
    IProductsRepository productsRepository) : IProductsService
{
    public async Task<Result<IEnumerable<ProductDto>>> GetAllProductsAsync()
    {
        logger.LogInformation("Fetching all products.");
        var productsResult = await productsRepository.GetAllProductsAsync();

        if (productsResult.IsFailed)
        {
            logger.LogError("Failed to fetch all products: {Errors}", productsResult.Errors);
            return Result.Fail(productsResult.Errors);
        }

        logger.LogInformation("Successfully fetched all products.");
        return Result.Ok(mapper.Map<IEnumerable<ProductDto>>(productsResult.Value));
    }

    public async Task<Result<IEnumerable<ProductDto>>> GetAllProductsPaginatedAsync(int page, int pageSize = 10)
    {
        logger.LogInformation("Fetching products for page '{Page}' with page size '{PageSize}'.", page, pageSize);
        var productsResult = await productsRepository.GetAllProductsPaginatedAsync(page, pageSize);

        if (productsResult.IsFailed)
        {
            logger.LogError("Failed to fetch paginated products: {Errors}", productsResult.Errors);
            return Result.Fail(productsResult.Errors);
        }

        logger.LogInformation("Successfully fetched paginated products.");
        return Result.Ok(mapper.Map<IEnumerable<ProductDto>>(productsResult.Value));
    }

    public async Task<Result<ProductDto>> GetProductByIdAsync(int id)
    {
        logger.LogInformation("Fetching product with ID '{Id}'.", id);
        var productResult = await productsRepository.GetProductByIdAsync(id);

        if (productResult.IsFailed)
        {
            logger.LogError("Failed to fetch product with ID '{Id}': {Errors}", id, productResult.Errors);
            return Result.Fail(productResult.Errors);
        }

        logger.LogInformation("Successfully fetched product with ID '{Id}'.", id);
        return Result.Ok(mapper.Map<ProductDto>(productResult.Value));
    }

    public async Task<Result<ProductDto>> UpdateDescriptionAsync(int id, string description)
    {
        logger.LogInformation("Updating description for product with ID '{Id}'.", id);
        var productResult = await productsRepository.UpdateDescriptionAsync(id, description);

        if (productResult.IsFailed)
        {
            logger.LogError("Failed to update description for product with ID '{Id}': {Errors}", id, productResult.Errors);
            return Result.Fail(productResult.Errors);
        }
        
        logger.LogInformation("Successfully updated description for product with ID '{Id}' at '{UpdatedAt}'.", id, productResult.Value.UpdatedAt);
        return Result.Ok(mapper.Map<ProductDto>(productResult.Value));
    }
}