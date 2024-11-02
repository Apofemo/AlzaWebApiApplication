using AlzaApp.Domain.DataTransferObjects;
using FluentResults;

namespace AlzaApp.Core.Interfaces;

public interface IProductsService
{
    Task<Result<IEnumerable<ProductDto>>> GetAllProductsAsync();
    Task<Result<IEnumerable<ProductDto>>> GetAllProductsPaginatedAsync(int page, int pageSize = 10);
    Task<Result<ProductDto>> GetProductByIdAsync(int id);
    Task<Result<ProductDto>> UpdateDescriptionAsync(int id, string description);
}