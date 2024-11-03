using AlzaApp.API.Endpoints;
using AlzaApp.API.OpenApi;
using AlzaApp.Core;
using AlzaApp.Persistence;
using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

if (builder.Environment.IsDevelopment());
{
    builder.Services.AddSwaggerGen();
}

builder.Services.AddLogging();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
})
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services
       .InjectCoreDependencies()
       .InjectPersistenceDependencies(builder.Configuration);

builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();

var app = builder.Build();

var versionSet = app.NewApiVersionSet()
                    .HasApiVersion(new ApiVersion(1))
                    .HasApiVersion(new ApiVersion(2))
                    .Build();

var groupBuilder = app.MapGroup("api/v{apiVersion:apiVersion}")
                      .WithApiVersionSet(versionSet);

groupBuilder.MapProductEndpointsV1()
            .MapProductEndpointsV2();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();

        foreach (var description in descriptions)
        {
            var ulr = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            
            options.SwaggerEndpoint(ulr, name);
        }
    });
}

app.UseHttpsRedirection();

await app.RunAsync();
