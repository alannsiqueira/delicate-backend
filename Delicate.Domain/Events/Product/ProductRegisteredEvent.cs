using System;
using Delicate.Domain.Core.Events;

namespace Delicate.Domain.Events.Product
{
    public class ProductRegisteredEvent : Event
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public ProductRegisteredEvent(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
            AggregateId = id;
        }
    }
}