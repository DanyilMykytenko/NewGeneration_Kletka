using Castle.Core.Internal;
using Kletka.Infrastructure.Data;
using Kletka.Infrastructure.Repository;
using System;
using System.Threading.Tasks;

namespace Kletka.Services
{
    public class LoginServicecs : ILoginService
    {
        private readonly IRepository _repository;

        public LoginServicecs(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<Users> CheckLogin(string login,string password)
        {
            var user = await _repository.GetUsersAsync(login,password);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
