using Castle.Core.Internal;
using Kletka.Infrastructure.Data;
using Kletka.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Services
{
    public class StatusesService : IStatusesService
    {
        private readonly IRepository _repository;

        public StatusesService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> AddUser(string status)
        {
            if (status.IsNullOrEmpty())
                throw new ArgumentNullException();

            var newUser = await _repository.AddAsync(new Statuses
            {
                Status = status
            });

            return newUser.Id;
        }

        public Task UpdateUser(int statusId, string name)
        {
            throw new NotImplementedException();
        }
    }
}
