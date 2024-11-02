using FluentResults;

namespace AlzaApp.Domain.DomainEntities.Errors.Core;

public sealed record DescriptionIsEmptyError : IError
{
    public string Message => "Description cannot be empty.";
    
    public Dictionary<string, object> Metadata => [];
    public List<IError> Reasons => [];

    public static DescriptionIsEmptyError Create() => new();
}