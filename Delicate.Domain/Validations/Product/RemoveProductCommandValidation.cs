using Delicate.Domain.Commands.Product;

namespace Delicate.Domain.Validations.Product
{
    public class RemoveProductCommandValidation : ProductValidation<RemoveProductCommand>
    {
        public RemoveProductCommandValidation()
        {
            ValidateId();
        }
    }
}