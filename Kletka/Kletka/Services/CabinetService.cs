using Kletka.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Services
{
    public class CabinetService : ICabinetService
    {
        public async Task uploadInformation(Accounts account)
        {
            if(account == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
