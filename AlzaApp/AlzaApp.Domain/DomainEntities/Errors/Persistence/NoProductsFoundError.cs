using FluentResults;

namespace AlzaApp.Domain.DomainEntities.Errors.Persistence;

public sealed record NoProductsFoundError : IError
{
    public string Message => "No products found.";
    
    public Dictionary<string, object> Metadata => [];
    public List<IError> Reasons => [];
    
    public static NoProductsFoundError Create() => new();
}