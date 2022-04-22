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
        public async Task<Users> Login(string username, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Login == username);
            var pass = await _dbContext.Users.FirstOrDefaultAsync(x => x.Password == password);

            if (user == null)
                return null;
            if (pass == null)
                return null;

            return user;
        }
        /*
public async Task<int> CheckExisting<TEntity>(string login, string password) where TEntity : class, IEntity
{
        var result = _dbContext.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
        return result.Id;
}
*/

    }
}
