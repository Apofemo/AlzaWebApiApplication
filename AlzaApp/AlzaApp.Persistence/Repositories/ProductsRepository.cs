using AlzaApp.Domain.DomainEntities;
using AlzaApp.Domain.Interfaces;
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AlzaApp.Persistence.Repositories;

internal class ProductsRepository(
    AppDbContext dbContext, 
    IMapper mapper,
    ILogger<ProductsRepository> logger) : IProductsRepository
{
    public async Task<Result<IEnumerable<Product>>> GetAllProductsAsync()
    {
        logger.LogInformation("Fetching all products from the database.");
        var products = await dbContext.Products
                                      .AsNoTracking()
                                      .ToListAsync();

        if (products.Count == 0)
            return Result.Fail("No products found.");

        logger.LogInformation("Successfully fetched '{Count}' products from the database.", products.Count);
        return Result.Ok(mapper.Map<IEnumerable<Product>>(products));
    }

    public async Task<Result<IEnumerable<Product>>> GetAllProductsPaginatedAsync(int page, int pageSize = 10)
    {
        logger.LogInformation("Fetching products from the database for page '{Page}' with page size '{PageSize}'.", page, pageSize);
        var products = await dbContext.Products
                                      .AsNoTracking()
                                      .Skip((page - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToListAsync();

        if (products.Count == 0)
            return Result.Fail("No products found.");

        logger.LogInformation("Successfully fetched '{Count}' products for page '{Page}'.", products.Count, page);
        return Result.Ok(mapper.Map<IEnumerable<Product>>(products));
    }

    public async Task<Result<Product>> GetProductByIdAsync(int id)
    {
        logger.LogInformation("Fetching product with ID '{Id}' from the database.", id);
        var product = await dbContext.Products
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
            return Result.Fail($"Product with ID '{id}' not found.");

        logger.LogInformation("Successfully fetched product with ID '{Id}'.", id);
        return Result.Ok(mapper.Map<Product>(product));
    }

    public async Task<Result<Product>> UpdateDescriptionAsync(int id, string description)
    {
        logger.LogInformation("Updating description for product with ID '{Id}'.", id);
        var product = await dbContext.Products
                                     .FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
            return Result.Fail($"Product with ID '{id}' not found");

        product.Description = description;
        product.UpdatedAt = DateTimeOffset.UtcNow;
        
        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Successfully updated description for product with ID '{Id}'.", id);
        return Result.Ok(mapper.Map<Product>(product));
    }
}