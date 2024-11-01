using AlzaApp.Domain.Interfaces;
using AlzaApp.Persistence;
using AlzaApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AlzaApp.Test.PersistenceTests;

internal abstract class BaseRepositoryTest
{
    protected ServiceProvider ServiceProvider { get; private set; }
    protected AppDbContext DbContext { get; private set; }
    
    protected abstract void SetUp();
    
    [SetUp]
    protected void Setup()
    {
        ServiceProvider = new ServiceCollection()
                          .AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("TestDatabase"))
                          .AddAutoMapper(typeof(MappingProfile))
                          .AddLogging()
                          .AddTransient<IProductsRepository, ProductsRepository>()
                          .BuildServiceProvider();
        
        DbContext = ServiceProvider.GetRequiredService<AppDbContext>();
        
        SetUp();
    }
    
    [TearDown]
    protected async Task TearDown()
    {
        await DbContext.Database.EnsureDeletedAsync();
        await DbContext.DisposeAsync();
    }
}