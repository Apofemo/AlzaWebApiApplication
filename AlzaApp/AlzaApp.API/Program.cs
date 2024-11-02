using AlzaApp.API.Endpoints;
using AlzaApp.Core;
using AlzaApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging();

builder.Services
       .InjectCoreDependencies()
       .InjectPersistenceDependencies(builder.Configuration);

var app = builder.Build();

app.MapProductEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

await app.RunAsync();
