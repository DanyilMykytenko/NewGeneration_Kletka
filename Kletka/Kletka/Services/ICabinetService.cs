using Kletka.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Services
{
    public interface ICabinetService
    {
        public Task<Accounts> uploadAccountInformation(int id);
        public Task<string> checkLogoForUpload(Users user);
    }
}
