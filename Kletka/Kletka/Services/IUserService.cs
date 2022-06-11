using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Services
{
    public interface IUserService
    {
        public Task<int> AddUser(string name, string contacts, DateTime time,
            string prjName, string login, string password,
            string email, string userType, int userStatusId, string rate);
        public Task UpdateUser(int userId, string name);
    }
}
