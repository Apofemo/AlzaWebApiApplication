using AlzaApp.Core.Interfaces;

namespace AlzaApp.API.Endpoints;

internal static partial class ProductsEndpoints
{
    internal static IEndpointRouteBuilder MapProductEndpointsV1(this IEndpointRouteBuilder app)
    {
        app.MapGet("products", async (IProductsService productService) =>
        {
            var result = await productService.GetAllProductsAsync();

            return result.ToHttpResult();
        }).MapToApiVersion(1);

        app.MapGet("products/{id:int}", async (IProductsService productService, int id) =>
        {
            var result = await productService.GetProductByIdAsync(id);

            return result.ToHttpResult();
        }).MapToApiVersion(1);

        app.MapPatch("products/{id:int}", async (IProductsService productService, int id, string description) =>
        {
            var result = await productService.UpdateDescriptionAsync(id, description);

            return result.ToHttpResult();
        }).MapToApiVersion(1);

        return app;
    }
}