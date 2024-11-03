using AlzaApp.Domain.DomainEntities;
using FluentResults;

namespace AlzaApp.Domain.Interfaces;

public interface IProductsRepository
{
    Task<Result<IEnumerable<Product>>> GetAllProductsAsync();
    Task<Result<IEnumerable<Product>>> GetAllProductsPaginatedAsync(int page, int pageSize);
    Task<Result<Product>> GetProductByIdAsync(int id);
    Task<Result<Product>> UpdateDescriptionAsync(int id, string description);
}