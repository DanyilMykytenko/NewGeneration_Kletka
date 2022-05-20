using Kletka.Exceptions;
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
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Login == username && x.Password == password);

            if (user == null)
                return null;

            return user;
        }

        public async Task<Users> GetUsersAsync(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
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

        public async Task<List<Accounts>> GetAccountsByAccountNumbersAsync(List<int> accountNumbers)
        {
            var accounts = await _dbContext.Accounts.Where(x => accountNumbers.Contains(x.AccountNumber)).ToListAsync();
            
            return accounts;
        }

        public async Task<List<Accounts>> MakeTransaction(int sendersAccountNumber, int receiversAccountNumber, int money)
        {
            if (sendersAccountNumber == -1 || receiversAccountNumber == -1) return new List<Accounts>();

            var accounts = await GetAccountsByAccountNumbersAsync(new List<int> { sendersAccountNumber, receiversAccountNumber });

            var sendersAccount = accounts.FirstOrDefault(a => a.AccountNumber == sendersAccountNumber);
            var receiversAccount = accounts.FirstOrDefault(a => a.AccountNumber == receiversAccountNumber);

            if(sendersAccount == null || receiversAccount == null)
            {
                return new List<Accounts>();
            }

            if (sendersAccount.Balance >= money)
            {
                sendersAccount.Balance -= money;
                receiversAccount.Balance += money;

                await _dbContext.SaveChangesAsync();
                return accounts;
            }
            else
            {
                throw new NoMoneyException();
            }
        }

    }
}
