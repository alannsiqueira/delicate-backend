using Delicate.Domain.Commands.Product;

namespace Delicate.Domain.Validations.Product
{
    public class UpdateProductCommandValidation : ProductValidation<UpdateProductCommand>
    {
        public UpdateProductCommandValidation()
        {
            When(product => product.Description != null, ValidateDescription);
            When(product => product.ShortDescription != null, ValidateShortDescription);
            ValidateName();
            ValidatePrice();
        }
    }
}