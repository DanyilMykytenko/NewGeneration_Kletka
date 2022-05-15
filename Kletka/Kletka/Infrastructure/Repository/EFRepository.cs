using Kletka.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Infrastructure.Repository
{
    public class EFRepository : IRepository
    {
        private readonly MVCDbContext _dbContext;

        public EFRepository(MVCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            var result = await _dbContext.Set<TEntity>()
                .AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            var result = _dbContext.Set<TEntity>()
                .Update(entity);

            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, IEntity
        {
            return _dbContext.Set<TEntity>()
                .Select(i => i);
        }
        public async Task<Users> GetUsersAsync(string username, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Login == username);
            var pass = await _dbContext.Users.FirstOrDefaultAsync(x => x.Password == password);

            if (user == null)
                return null;

            if (pass == null)
                return null;

            return user;
        }
        public async Task<Accounts> GetAccountsByUserAsync(int id)
        {
            var account = await _dbContext.Accounts.FirstOrDefaultAsync(x => x.OwnerId == id);
            if (account == null)
                   return null;
            return account;
        }
        public async Task<Accounts> GetAccountByAccountNumberAsync(int accountNumber)
        {
            var account = await _dbContext.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == accountNumber);
            if (account == null)
                return null;
            return account;
        }

        public async Task<bool> makeTransaction(Accounts sendersAccount, int accountNumber, int money)
        {
            if (accountNumber == -1) return false;
            if(sendersAccount == null || accountNumber == 0)
            {
                throw new ArgumentNullException();
            }
            var receiversAccount = await GetAccountByAccountNumberAsync(accountNumber);
            if (sendersAccount.Balance > money)
            {
                sendersAccount.Balance -= money;
                receiversAccount.Balance += money;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
