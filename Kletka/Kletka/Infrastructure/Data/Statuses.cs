using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Infrastructure.Data
{
    public class Statuses : IEntity
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Users> Users { get; set; } = new HashSet<Users>();
    }
}
