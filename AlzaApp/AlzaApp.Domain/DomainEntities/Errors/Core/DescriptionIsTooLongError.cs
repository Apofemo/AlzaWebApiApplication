using FluentResults;

namespace AlzaApp.Domain.DomainEntities.Errors.Core;

public sealed record DescriptionIsTooLongError : IError
{
    public string Message => "Description cannot be longer than 1000 characters.";
    
    public Dictionary<string, object> Metadata => [];
    public List<IError> Reasons => [];

    public static DescriptionIsTooLongError Create() => new();
}