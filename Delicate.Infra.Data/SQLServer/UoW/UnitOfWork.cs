using Delicate.Domain.Interfaces;
using Delicate.Infra.Data.SQLServer.Context;

namespace Delicate.Infra.Data.SQLServer.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext _context;

        public UnitOfWork(SqlServerContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}