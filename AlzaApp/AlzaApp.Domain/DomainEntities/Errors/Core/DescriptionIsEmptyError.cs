using FluentResults;

namespace AlzaApp.Domain.DomainEntities.Errors.Core;

public sealed record DescriptionIsEmptyError : IError
{
    public string Message { get; private init; } = string.Empty;
    public Dictionary<string, object> Metadata { get; private init; } = [];
    public List<IError> Reasons => [];
    
    public static DescriptionIsEmptyError Create() => new()
    {
        Message = "Description cannot be empty.",
        
        Metadata = new()
        {
            { nameof(ErrorCode), ErrorCode.BadRequest }
        }
    };
}