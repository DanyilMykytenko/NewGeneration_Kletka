using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Services
{
    public interface IAccountService
    {
        public Task<int> AddAccount(int ownerId, string type);
    }
}
