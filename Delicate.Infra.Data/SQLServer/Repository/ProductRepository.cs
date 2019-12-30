using Delicate.Domain.Interfaces;
using Delicate.Domain.Models;
using Delicate.Infra.Data.SQLServer.Context;

namespace Delicate.Infra.Data.SQLServer.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SqlServerContext context) : base(context)
        {

        }
    }
}