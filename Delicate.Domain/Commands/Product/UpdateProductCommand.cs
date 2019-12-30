using System;
using Delicate.Domain.Validations.Product;

namespace Delicate.Domain.Commands.Product
{
    public  class UpdateProductCommand : ProductCommand
    {
        public UpdateProductCommand(Guid id, string name, string description, string shortDescription, decimal price)
        {
            Id = id;
            Name = name?.TrimStart().TrimEnd();
            Description = description?.TrimStart().TrimEnd();
            ShortDescription = shortDescription?.TrimStart().TrimEnd();
            Price = price;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}