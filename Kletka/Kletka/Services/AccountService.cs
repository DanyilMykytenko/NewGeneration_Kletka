using Castle.Core.Internal;
using Kletka.Infrastructure.Data;
using Kletka.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Kletka.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository _repository;

        public AccountService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> AddAccount(int ownerId, string type)
        {
            if (ownerId.Equals(0) || type.IsNullOrEmpty())
                throw new ArgumentNullException();

            var newUser = await _repository.AddAsync(new Accounts
            {
                OwnerId = ownerId,
                AccountNumber = await generateAccountNumber(),
                Balance = 0,
                Type = type,
                APIKey = await generateAPIKey(),
                CVVCode = await generateCVVCode(),
                AccountStatus = "Just new."
            });

            return newUser.Id;
        }
        private async Task<long> generateAccountNumber()
        {
            long accountNumber = 0;
            Random rnd = new Random();
            while (true)
            {
                accountNumber = 555532322323 + rnd.Next(4000, 5000);
                var check = await _repository.GetAll<Accounts>()
                    .FirstOrDefaultAsync(u => u.AccountNumber == accountNumber);
                if (check == null)
                    break;
                else
                    continue;
            }
            return accountNumber;
        }
        private async Task<string> generateAPIKey()
        {
            var key = new byte[32];
            using (var generator = RandomNumberGenerator.Create())
                generator.GetBytes(key);
            string apiKey = Convert.ToBase64String(key);
            return apiKey;
        }
        private async Task<int> generateCVVCode()
        {
            int CVVCode = 0;
            Random rnd = new Random();
            while(true)
            {
                CVVCode = rnd.Next(100, 999);
                var check = await _repository.GetAll<Accounts>()
                    .FirstOrDefaultAsync(u => u.AccountNumber == CVVCode);
                if (check == null)
                    break;
                else
                    continue;
            }
            return CVVCode;
        }
    }
}
