using Castle.Core.Internal;
using Kletka.Infrastructure.Data;
using Kletka.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> AddUser(string name, string contacts, DateTime time, 
            string prjName, string login, string password, 
            string email, string userType, int userStatusId, string rate)
        {
            if (name.IsNullOrEmpty())
                throw new ArgumentNullException();

            var newUser = await _repository.AddAsync(new Users
            {
                FullName = name,
                Contacts = contacts,
                BirthDate = time,
                ProjectName = prjName,
                Login = login,
                Password = password,
                Email = email,
                UserType = userType,
                UserStatusId = userStatusId,
                Rate = rate
            });

            return newUser.id;
        }

        public async Task UpdateUser(int userId, string name)
        {
            var user = await _repository.GetAll<Users>()
                .FirstOrDefaultAsync(u => u.id == userId);

            user.FullName = name;

            await _repository.UpdateAsync(user);
        }
    }
}
