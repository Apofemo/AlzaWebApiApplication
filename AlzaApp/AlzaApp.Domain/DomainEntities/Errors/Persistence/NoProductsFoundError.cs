using FluentResults;

namespace AlzaApp.Domain.DomainEntities.Errors.Persistence;

public sealed record NoProductsFoundError : IError
{
    public string Message => "No products found.";
    
    public Dictionary<string, object> Metadata => new();
    public List<IError> Reasons => new();
    
    public static NoProductsFoundError Create() => new();
}