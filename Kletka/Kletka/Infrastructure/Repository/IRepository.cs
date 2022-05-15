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
        public Task<Users> GetUsersAsync(string login, string password);
        public Task<Accounts> GetAccountsByUserAsync(int id);
        public Task<Accounts> GetAccountByAccountNumberAsync(int accountNumber);
        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, IEntity;
        public Task<bool> makeTransaction(Accounts sendersAccount, int accountNumber, int money);
    }
}
