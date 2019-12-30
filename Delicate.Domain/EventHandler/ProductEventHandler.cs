using System.Threading;
using System.Threading.Tasks;
using Delicate.Domain.Events.Product;
using MediatR;

namespace Delicate.Domain.EventHandler
{
    public class ProductEventHandler:INotificationHandler<ProductRegisteredEvent>
    {
        public  Task Handle(ProductRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}