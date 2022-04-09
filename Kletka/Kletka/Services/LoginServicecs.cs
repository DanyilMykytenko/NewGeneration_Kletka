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
        public async Task<int> CheckLogin(string login,string password)
        {
            var tasks = await _repository.Login(login,password);
            if (tasks == null)
            {
                return 0;
            }
            return tasks.Id;
        }
    }
}
