using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Infrastructure.Data
{
    public class Users : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Contacts{ get; set; }
        public DateTime BirthDate { get; set; }
        public string ProjectName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public int UserStatusId { get; set; }
        public string Rate { get; set; }

        public virtual ICollection<Accounts> Account { get; set; } = new HashSet<Accounts>();

        public virtual Statuses Status { get; set; }
        public virtual ICollection<Accidents> Accident { get; set; } = new HashSet<Accidents>();
    }
}
