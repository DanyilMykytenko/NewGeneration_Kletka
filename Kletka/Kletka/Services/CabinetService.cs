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

        public async Task<string> checkLogoForUpload(Users user)
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

        public async Task<Accounts> uploadAccountInformation(int id)
        {
            var Account = await _repository.GetAccountsByUserAsync(id);
            return Account;
        }
    }
}
