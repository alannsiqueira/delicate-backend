using System;

namespace Delicate.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
         bool Commit();
    }
}