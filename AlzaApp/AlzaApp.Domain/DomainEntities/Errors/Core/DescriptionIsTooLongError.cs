using FluentResults;

namespace AlzaApp.Domain.DomainEntities.Errors.Core;

public sealed record DescriptionIsTooLongError : IError
{
    public string Message { get; private init; } = string.Empty;
    public Dictionary<string, object> Metadata { get; private init; } = [];
    public List<IError> Reasons => [];
    
    public static DescriptionIsTooLongError Create() => new()
    {
        Message = "Description cannot be longer than 1000 characters.",
        
        Metadata = new()
        {
            { nameof(ErrorCode), ErrorCode.BadRequest }
        }
    };
}
