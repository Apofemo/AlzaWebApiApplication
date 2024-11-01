using AlzaApp.Domain.DomainEntities;

namespace AlzaApp.Domain.Interfaces;

public interface IProductsRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<IEnumerable<Product>> GetAllProductsPaginatedAsync(int page, int pageSize = 10);
    Task<Product> GetProductByIdAsync(int id);
    Task<Product> UpdateDescriptionAsync(int id, string description);
}