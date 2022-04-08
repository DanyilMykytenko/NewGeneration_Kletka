using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Infrastructure.Data
{
    public class Accounts : IEntity
    {
        public int id { get; set; }
        public int OwnerId { get; set; }
        public int AccountNumber { get; set; }
        public double? Balance{ get; set; }
        public string Type { get; set; }
        public string APIKey{ get; set; }
        public int CVVCode{ get; set; }
        public string AccountStatus { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Transactions> SendedTransactions { get; set; } = new HashSet<Transactions>();
        public virtual ICollection<Transactions> ReceivedTransactions { get; set; } = new HashSet<Transactions>();
    }
}
