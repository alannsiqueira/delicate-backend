using AutoMapper;
using Delicate.Application.ViewModels;
using Delicate.Domain.Models;

namespace Delicate.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
