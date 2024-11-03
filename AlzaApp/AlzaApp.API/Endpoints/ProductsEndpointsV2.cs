using AlzaApp.Core.Interfaces;

namespace AlzaApp.API.Endpoints;

internal static partial class ProductsEndpoints
{
    internal static IEndpointRouteBuilder MapProductEndpointsV2(this IEndpointRouteBuilder app)
    {
        app.MapGet("products", async (IProductsService productService, int page, int? pageSize) =>
        {
            var result = await productService.GetAllProductsPaginatedAsync(page, pageSize);
                
            return result.ToHttpResult();
        }).MapToApiVersion(2);

        return app;
    }
}