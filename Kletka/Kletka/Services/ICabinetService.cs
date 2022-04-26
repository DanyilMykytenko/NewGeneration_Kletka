using Kletka.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Services
{
    interface ICabinetService
    {
        public Task uploadInformation(Accounts account);
    }
}
