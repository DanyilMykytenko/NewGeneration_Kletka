using Kletka.Infrastructure.Data;
using Kletka.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Services
{
    public class CabinetService : ICabinetService
    {
        private readonly IRepository _repository;
        public CabinetService(IRepository repository)
        {
            _repository = repository;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<string> CheckLogoForUpload(Users user)

        {
            if(user == null)
            {
                throw new ArgumentNullException("user"); 
            }
            if (user.UserType == "Admin")
            {
                return "voenkom.jpg";
            }
            else
            {
                return "chmonya.jpg";
            }
        }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

        public async Task<Accounts> GetAccountInformation(int id)
        {
            var Account = await _repository.GetAccountsByUserAsync(id);
            return Account;
        }
    }
}
