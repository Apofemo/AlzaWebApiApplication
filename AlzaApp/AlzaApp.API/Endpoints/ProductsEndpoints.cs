using AlzaApp.Core.Interfaces;

namespace AlzaApp.API.Endpoints;

internal static class ProductsEndpoints
{
    internal static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
    // Version 1
        app.MapGet("products", async (IProductsService productService) =>
        {
            var result = await productService.GetAllProductsAsync();
            
            return result.IsSuccess 
                ? Results.Ok(result.Value) 
                : Results.NotFound(result.Errors.First().Message);
        }).MapToApiVersion(1);

        app.MapGet("products/{id:int}", async (IProductsService productService, int id) =>
        {
            var result = await productService.GetProductByIdAsync(id);
            
            return result.IsSuccess 
                ? Results.Ok(result.Value) 
                : Results.NotFound(result.Errors.First().Message);
        }).MapToApiVersion(1);

        app.MapPatch("products/{id:int}", async (IProductsService productService, int id, string description) =>
        {
            var result = await productService.UpdateDescriptionAsync(id, description);
            
            return result.IsSuccess 
                ? Results.Ok(result.Value) 
                : Results.BadRequest(result.Errors.First().Message);
        }).MapToApiVersion(1);
        
    // Version 2
        app.MapGet("products", async (IProductsService productService, int page, int? pageSize) =>
        {
            if (page <= 0)
                return Results.BadRequest("Page must be greater than 0.");
            
            if (pageSize is <= 0)
                return Results.BadRequest("Page size must be greater than 0.");
            
            var result = pageSize is null 
                ? await productService.GetAllProductsPaginatedAsync(page)
                : await productService.GetAllProductsPaginatedAsync(page, pageSize.Value);
                
            return result.IsSuccess 
                ? Results.Ok(result.Value) 
                : Results.NotFound(result.Errors.First().Message);
        }).MapToApiVersion(2);
    }
}