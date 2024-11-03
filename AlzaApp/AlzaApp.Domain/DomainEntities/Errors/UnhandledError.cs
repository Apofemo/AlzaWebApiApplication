using FluentResults;

namespace AlzaApp.Domain.DomainEntities.Errors;

public sealed record UnhandledError : IError
{
    public string Message { get; private init; } = string.Empty;
    public Dictionary<string, object> Metadata { get; private init; } = [];
    public List<IError> Reasons => [];
    
    public static UnhandledError Create() => new()
    {
        Message = "Please try again later or contact our support.",
        
        Metadata = new()
        {
            { nameof(ErrorCode), ErrorCode.InternalServerError }
        }
    };
}