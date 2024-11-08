using FluentResults;

namespace AlzaApp.Domain.DomainEntities.Errors.Persistence;

public sealed record NoProductsFoundError : IError
{
    public string Message { get; private init; } = string.Empty;
    public Dictionary<string, object> Metadata { get; private init; } = [];
    public List<IError> Reasons => [];
    
    public static NoProductsFoundError Create() => new()
    {
        Message = "No products found.",
        
        Metadata = new()
        {
            { nameof(ErrorCode), ErrorCode.NotFound }
        }
    };
}