using System;
using Delicate.Domain.Commands.Product;
using FluentValidation;

namespace Delicate.Domain.Validations.Product
{
    public class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }


        protected void ValidateName()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithName("Nome")
                .Length(2,150);
        }


        protected void ValidateDescription()
        {
            RuleFor(p => p.Description)
                .NotEmpty()
                .WithName("Descrição")
                .Length(2, 150);
        }
        

        protected void ValidateShortDescription()
        {
            RuleFor(p => p.ShortDescription)
                .NotEmpty()
                .WithName("Descrição curta")
                .Length(2, 90);
        }

        protected void ValidatePrice()
        {
            RuleFor(p => p.Price)
                .NotNull()
                .WithName("Preço")
                .GreaterThan(0);
        }


    }
}