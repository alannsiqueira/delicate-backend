using AutoMapper;
using Delicate.Application.ViewModels;
using Delicate.Domain.Commands.Product;

namespace Delicate.Application.AutoMapper
{
    public class CommandToViewModelMappingProfile : Profile
    {
        public CommandToViewModelMappingProfile()
        {
            CreateMap<RegisterNewProductCommand, ProductViewModel>();
        }
    }
}
