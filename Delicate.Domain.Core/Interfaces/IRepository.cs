using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Delicate.Domain.Core.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity entity);
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(Guid id);
        void Remove(Func<TEntity, bool> where);

        TEntity GetById(Guid id, bool asNoTracking = false);
        Task<TEntity> GetByIdAsync(Guid id, bool asNoTracking = false);
        
        IQueryable<TEntity> GetAll(bool asNoTracking = false);
        IQueryable<TEntity> GetAll(Expression < Func<TEntity, bool>> where, bool asNoTracking = false);
        IQueryable<TEntity> GetAll(Expression < Func<TEntity, bool>> where, Expression<Func<TEntity, object>> orderBy, bool asNoTracking = false);

        int SaveChanges();
    }
}