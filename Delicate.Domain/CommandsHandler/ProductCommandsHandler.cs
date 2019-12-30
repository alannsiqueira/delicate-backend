using System;
using System.Threading;
using System.Threading.Tasks;
using Delicate.Domain.Commands.Product;
using Delicate.Domain.Core.Bus;
using Delicate.Domain.Core.Notifications;
using Delicate.Domain.Events.Product;
using Delicate.Domain.Interfaces;
using Delicate.Domain.Models;
using MediatR;

namespace Delicate.Domain.CommandsHandler
{
    public class ProductCommandsHandler : CommandHandler,
        IRequestHandler<RegisterNewProductCommand, bool>,
        IRequestHandler<UpdateProductCommand, bool>,
        IRequestHandler<RemoveProductCommand, bool>
    {

        private readonly IProductRepository _repository;
        private readonly IMediatorHandler Bus;

        public ProductCommandsHandler(IUnitOfWork uow, IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications, IProductRepository repository) : base(uow, bus, notifications)
        {
            _repository = repository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(Guid.NewGuid(), request.Name, request.Description, request.ShortDescription, request.Price);
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            _repository.AddAsync(product);

            if (Commit())
            {
                Bus.RaiseEvent(new ProductRegisteredEvent(product.Id, product.Name, product.Price));
            }

            return Task.FromResult(true);
        }

        public  Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Id ,request.Name, request.Description, request.ShortDescription, request.Price);
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            _repository.Update(product);

            if (Commit())
            {
                Bus.RaiseEvent(new ProductUpdatedEvent());
            }

            return Task.FromResult(true);
        }

        public  Task<bool> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            _repository.Remove(request.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new ProductUpdatedEvent());
            }

            return Task.FromResult(true);
        }
    }
}