using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Services
{
    public interface IStatusesService
    {
        public Task<int> AddUser(string Status);
        public Task UpdateUser(int statusId, string name);
    }
}
