using System;
using Delicate.Domain.Core.Models;

namespace Delicate.Domain.Models
{
    public class Product : Entity
    {
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string ShortDescription { get;  set; }
        public decimal Price { get;  set; }


        public Product(
            Guid id,
            string name,
            string description,
            string shortDescription,
            decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            ShortDescription = shortDescription;
            Price = price;
        }

        // Empty constructor for EF
        public Product() { }


    }
}