using Castle.Core.Internal;
using Kletka.Extensions;
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
        public async Task<Users> CheckToken(string token)
        {
            var userId = int.Parse(token.Split(":")[0]);
            var user = await _repository.GetUsersAsync(userId);
            if (user == null)
            {
                return null;
            }

            if(CreateToken(userId, user.Password) != token)
            {
                return null;
            }

            return user;
        }

        public string CreateToken(int userId, string password)
        {
            return $"{userId}:{password.GenerateSHA256Hash()}";
        }
    }
}
