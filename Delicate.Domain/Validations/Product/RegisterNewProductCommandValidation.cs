using Delicate.Domain.Commands.Product;

namespace Delicate.Domain.Validations.Product
{
    public class RegisterNewProductCommandValidation:ProductValidation<RegisterNewProductCommand>
    {
        public RegisterNewProductCommandValidation()
        {
            When(product => product.Description != null, ValidateDescription);
            When(product => product.ShortDescription != null, ValidateShortDescription);
            ValidateName();
            ValidatePrice();
        }
    }
}