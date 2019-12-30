using AutoMapper;
using Delicate.Application.ViewModels;
using Delicate.Domain.Commands.Product;

namespace Delicate.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, RegisterNewProductCommand>()
                .ConstructUsing(product =>
                    new RegisterNewProductCommand(product.Name, product.Description, product.ShortDescription, product.Price)
                );

            CreateMap<ProductViewModel, UpdateProductCommand>()
                .ConstructUsing(product =>
                    new UpdateProductCommand(product.Id, product.Name, product.Description, product.ShortDescription, product.Price)
                );
        }
    }
}
