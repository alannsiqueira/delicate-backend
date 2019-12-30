using System;
using Delicate.Domain.Core.Commands;

namespace Delicate.Domain.Commands.Product
{
    public abstract class ProductCommand: Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string ShortDescription { get; protected set; }
        public decimal Price { get; protected set; }

    }
}