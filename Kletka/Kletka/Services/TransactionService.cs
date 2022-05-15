using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kletka.Infrastructure.Data;
using Kletka.Infrastructure.Repository;

namespace Kletka.Services
{
    public class TransactionService : ITransactionsService
    {
        private readonly IRepository _repository;
        public TransactionService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> checkingForTransaction(Accounts sendersAccount, int NumberAccount, int money)
        {
            bool isSuccessfull = await _repository.makeTransaction(sendersAccount, NumberAccount, money);

            return isSuccessfull;
        }
    }
}
