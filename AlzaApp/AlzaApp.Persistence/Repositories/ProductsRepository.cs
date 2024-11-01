using AlzaApp.Domain.DomainEntities;
using AlzaApp.Domain.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AlzaApp.Persistence.Repositories;

internal class ProductsRepository(
    AppDbContext dbContext, 
    IMapper mapper,
    ILogger<ProductsRepository> logger) : IProductsRepository
{
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        logger.LogInformation("Fetching all products from the database.");
        var products = await dbContext.Products.AsNoTracking().ToListAsync();

        if (products.Count == 0)
        {
            logger.LogWarning("No products found in the database.");
            return Enumerable.Empty<Product>();
        }

        logger.LogInformation("Successfully fetched '{Count}' products from the database.", products.Count);
        return mapper.Map<IEnumerable<Product>>(products);
    }

    public async Task<IEnumerable<Product>> GetAllProductsPaginatedAsync(int page, int pageSize = 10)
    {
        logger.LogInformation("Fetching products from the database for page '{Page}' with page size '{PageSize}'.", page, pageSize);
        var products = await dbContext.Products.AsNoTracking()
                                       .Skip((page - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

        if (products.Count == 0)
        {
            logger.LogWarning("No products found for the specified page and page size.");
            return Enumerable.Empty<Product>();
        }

        logger.LogInformation("Successfully fetched '{Count}' products for page '{Page}'.", products.Count, page);
        return mapper.Map<IEnumerable<Product>>(products);
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        logger.LogInformation("Fetching product with ID '{Id}' from the database.", id);
        var product = await dbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
        {
            logger.LogWarning("Product with ID '{Id}' not found.", id);
            return Product.Empty;
        }

        logger.LogInformation("Successfully fetched product with ID '{Id}'.", id);
        return mapper.Map<Product>(product);
    }

    public async Task<Product> UpdateDescriptionAsync(int id, string description)
    {
        logger.LogInformation("Updating description for product with ID '{Id}'.", id);
        var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
        {
            logger.LogWarning("Product with ID '{Id}' not found.", id);
            return Product.Empty;
        }

        product = product with { Description = description };
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Successfully updated description for product with ID '{Id}'.", id);
        return mapper.Map<Product>(product);
    }
}