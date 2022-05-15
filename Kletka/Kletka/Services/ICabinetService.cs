using Kletka.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Services
{
    public interface ICabinetService
    {
        public Task<Accounts> GetAccountInformation(int id);
        public Task<string> CheckLogoForUpload(Users user);
    }
}
