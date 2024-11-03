using AlzaApp.Domain.DomainEntities;
using AlzaApp.Domain.DomainEntities.Errors.Persistence;
using AlzaApp.Domain.Interfaces;
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace AlzaApp.Persistence.Repositories;

internal sealed class ProductsRepository(
    AppDbContext dbContext, 
    IMapper mapper) : IProductsRepository
{
    public async Task<Result<IEnumerable<Product>>> GetAllProductsAsync()
    {
        var products = await dbContext.Products
                                      .AsNoTracking()
                                      .ToListAsync();

        return products.Count == 0 
            ? Result.Fail(NoProductsFoundError.Create()) 
            : Result.Ok(mapper.Map<IEnumerable<Product>>(products));
    }

    public async Task<Result<IEnumerable<Product>>> GetAllProductsPaginatedAsync(int page, int pageSize)
    {
        var products = await dbContext.Products
                                      .AsNoTracking()
                                      .Skip((page - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToListAsync();

        return products.Count == 0 
            ? Result.Fail(NoProductsFoundError.Create()) 
            : Result.Ok(mapper.Map<IEnumerable<Product>>(products));
    }

    public async Task<Result<Product>> GetProductByIdAsync(int id)
    {
        var product = await dbContext.Products
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(p => p.Id == id);

        return product is null 
            ? Result.Fail(NoProductWithIdFoundError.Create(id)) 
            : Result.Ok(mapper.Map<Product>(product));
    }

    public async Task<Result<Product>> UpdateDescriptionAsync(int id, string description)
    {
        var product = await dbContext.Products
                                     .FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
            return Result.Fail(NoProductWithIdFoundError.Create(id));

        product.Description = description;
        product.UpdatedAt = DateTimeOffset.UtcNow;
        
        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync();

        return Result.Ok(mapper.Map<Product>(product));
    }
}