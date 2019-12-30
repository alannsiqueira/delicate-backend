using System;
using Delicate.Domain.Core.Models;
using Delicate.Infra.Data.SQLServer.Context;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Delicate.Tests.Utils
{
    public static class Context<TEntity> where TEntity : Entity
    {

        public static Mock<SqlServerContext> GetMockContext()
        {
            var contextOption = new DbContextOptionsBuilder<SqlServerContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var context = new Mock<SqlServerContext>(contextOption);
            var dbSetMock = new Mock<DbSet<TEntity>>();
            context.Setup(c => c.Set<TEntity>()).Returns(dbSetMock.Object);

            return context;
        }
    }
}