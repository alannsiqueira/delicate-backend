using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Delicate.Domain.Core.Interfaces;
using Delicate.Domain.Core.Models;
using Delicate.Infra.Data.SQLServer.Context;
using Microsoft.EntityFrameworkCore;

namespace Delicate.Infra.Data.SQLServer.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly SqlServerContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(SqlServerContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }


        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity).ConfigureAwait(false);
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }


        public void Update(TEntity entity)
        {
            var existingEntity = DbSet.Find(entity.Id);
            if (existingEntity != null)
                DbSet.Update(entity);
        }


        public void Remove(Guid id)
        {
            var entity = DbSet.Find(id);
            if (entity != null) DbSet.Remove(entity);
        }

        public void Remove(Func<TEntity, bool> where)
        {
            DbSet.RemoveRange(DbSet.ToList().Where(where));
        }

        public TEntity GetById(Guid id, bool asNoTracking = false)
        {
            return asNoTracking
                ? DbSet.AsNoTracking().SingleOrDefault(entity => entity.Id == id)
                : DbSet.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(Guid id, bool asNoTracking = false)
        {
            return asNoTracking
                ? await DbSet.AsNoTracking().SingleOrDefaultAsync(entity => entity.Id == id).ConfigureAwait(false)
                : await DbSet.FindAsync(id).ConfigureAwait(false);
        }

        public IQueryable<TEntity> GetAll(bool asNoTracking = false)
        {
            return asNoTracking
                ? DbSet.AsNoTracking()
                : DbSet;
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> where, bool asNoTracking = false)
        {
            return asNoTracking
                ? DbSet.AsNoTracking().Where(where)
                : DbSet.Where(where);

        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> orderBy, bool asNoTracking = false)
        {
            return asNoTracking
                ? DbSet.AsNoTracking().OrderBy(orderBy).Where(where)
                : DbSet.OrderBy(orderBy).Where(where);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}