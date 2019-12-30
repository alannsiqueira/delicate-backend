using Delicate.Domain.Validations.Product;

namespace Delicate.Domain.Commands.Product
{
    public class RegisterNewProductCommand : ProductCommand
    {
        public RegisterNewProductCommand(string name, string description, string shortDescription, decimal price)
        {
            Name = name?.TrimStart().TrimEnd();
            Description = description?.TrimStart().TrimEnd();
            ShortDescription = shortDescription?.TrimStart().TrimEnd();
            Price = price;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}