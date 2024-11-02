using AlzaApp.Core;
using AlzaApp.Core.Interfaces;
using AlzaApp.Core.Services;
using AlzaApp.Domain.Interfaces;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace AlzaApp.Test.CoreTests;

internal abstract class BaseCoreTest
{
    protected ServiceProvider ServiceProvider { get; private set; }
    protected Mock<IProductsRepository> ProductsRepositoryMock { get; private set; }
    protected IMapper Mapper { get; private set; }
    
    protected abstract void SetUp();
    
    [SetUp]
    protected void Setup()
    {
        ProductsRepositoryMock = new Mock<IProductsRepository>();
        
        ServiceProvider = new ServiceCollection()
                          .AddAutoMapper(typeof(MappingProfile))
                          .AddLogging()
                          .AddTransient<IProductsService, ProductsService>()
                          .AddSingleton(ProductsRepositoryMock.Object)
                          .BuildServiceProvider();
        
        Mapper = ServiceProvider.GetRequiredService<IMapper>();
        
        SetUp();
    }
}