using Kletka.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Services
{
    public interface ITransactionsService
    {
        public Task<List<Accounts>> MakeTransaction(int senderAccountNumber, int receiverAccountNumber, int money);
    }
}
