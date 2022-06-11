using System.Threading.Tasks;
using Kletka.Infrastructure.Data;

namespace Kletka.Services
{
    public interface ILoginService
    {

        public Task<Users> CheckLogin(string login, string password);

        public Task<Users> CheckToken(string token);

        public string CreateToken(int userId, string password);

    }
}
