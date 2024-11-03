using AlzaApp.Domain.DomainEntities.Errors;
using FluentResults;

namespace AlzaApp.API.Endpoints;

internal static class ResultMapper
{
    internal static IResult ToHttpResult<TValue>(this FluentResults.IResult<TValue> result)
    {
        if (result.IsSuccess)
            return Results.Ok(result.Value);
        
        if (result.Errors.Count == 0)
            return Results.Problem();
        
        var mainError = result.Errors.First();

        return mainError.GetErrorCode() switch
        {
            ErrorCode.BadRequest => Results.BadRequest(mainError.Message),
            
            ErrorCode.NotFound => Results.NotFound(mainError.Message),
            
            ErrorCode.InternalServerError => Results.Problem(mainError.Message),
            
            _ => Results.Problem()
        };
    }
    
    private static ErrorCode GetErrorCode(this IError error)
    {
        return error.Metadata.TryGetValue(nameof(ErrorCode), out var errorCode)
            ? (ErrorCode) errorCode
            : ErrorCode.BadRequest;
    }
}