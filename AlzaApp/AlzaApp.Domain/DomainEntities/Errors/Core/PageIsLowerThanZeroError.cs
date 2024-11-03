using FluentResults;

namespace AlzaApp.Domain.DomainEntities.Errors.Core;

public sealed record PageIsLowerThanZeroError : IError
{
    public string Message { get; private init; } = string.Empty;
    public Dictionary<string, object> Metadata { get; private init; } = [];
    public List<IError> Reasons => [];
    
    public static PageIsLowerThanZeroError Create() => new()
    {
        Message = "Page must be greater than 0.",
        
        Metadata = new()
        {
            { nameof(ErrorCode), ErrorCode.BadRequest }
        }
    };
}