using Kletka.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Infrastructure.Repository
{
    public interface IRepository
    {
        public Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class, IEntity;
        public Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IEntity;
        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, IEntity;
    }
}
