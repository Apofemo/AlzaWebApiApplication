using FluentResults;

namespace AlzaApp.Domain.DomainEntities.Errors.Persistence;

public sealed record NoProductWithIdFoundError : IError
{
    public string Message { get; private init; } = string.Empty;
    public Dictionary<string, object> Metadata { get; private init; } = [];
    public List<IError> Reasons => [];
    
    public static NoProductWithIdFoundError Create(int id) => new()
    {
        Message = $"Product with ID '{id}' not found.",
        
        Metadata = new()
        {
            { nameof(ErrorCode), ErrorCode.NotFound }
        }
    };
}