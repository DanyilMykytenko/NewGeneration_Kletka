using System.Threading.Tasks;
using Kletka.Infrastructure.Data;

namespace Kletka.Services
{
    public interface ILoginService
    {

        public Task<int> CheckLogin(string login, string password);

    }
}
