using AutoMapper;
using Delicate.Domain.Commands.Product;
using Delicate.Domain.Models;

namespace Delicate.Application.AutoMapper
{
    public class DomainToCommandMappingProfile : Profile
    {
        public DomainToCommandMappingProfile()
        {
            CreateMap<Product, RegisterNewProductCommand>();
        }
    }
}
