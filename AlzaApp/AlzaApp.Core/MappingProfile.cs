using AlzaApp.Domain.DataTransferObjects;
using AlzaApp.Domain.DomainEntities;
using AutoMapper;

namespace AlzaApp.Core;

internal sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}