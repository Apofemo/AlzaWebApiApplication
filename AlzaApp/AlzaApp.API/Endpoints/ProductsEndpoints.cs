using AlzaApp.Core.Interfaces;

namespace AlzaApp.API.Endpoints;

public static class ProductsEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/products", async (IProductsService productService) =>
        {
            var result = await productService.GetAllProductsAsync();
            
            return result.IsSuccess 
                ? Results.Ok(result.Value) 
                : Results.NotFound(result.Errors.First().Message);
        });

        app.MapGet("api/products/{id}", async (IProductsService productService, int id) =>
        {
            var result = await productService.GetProductByIdAsync(id);
            
            return result.IsSuccess 
                ? Results.Ok(result.Value) 
                : Results.NotFound(result.Errors.First().Message);
        });

        app.MapPatch("api/products/{id}", async (IProductsService productService, int id, string description) =>
        {
            var result = await productService.UpdateDescriptionAsync(id, description);
            
            return result.IsSuccess 
                ? Results.Ok(result.Value) 
                : Results.BadRequest(result.Errors.First().Message);
        });
    }
}