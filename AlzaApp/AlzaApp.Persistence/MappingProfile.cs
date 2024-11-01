using AlzaApp.Domain.DomainEntities;
using AlzaApp.Persistence.DatabaseObjects;
using AutoMapper;

namespace AlzaApp.Persistence;

internal sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDo, Product>();
    }
}