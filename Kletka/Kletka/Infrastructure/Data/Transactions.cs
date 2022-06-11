using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Infrastructure.Data
{
    public class Transactions : IEntity
    {
        public int Id { get; set; }
        public DateTime TransactionDatetime { get; set; }
        public int SendersAccountId { get; set; }
        public int ReceiversAccountId { get; set; }
        public double TransactionAmount { get; set; }
        public string TransactionDescription { get; set; }
        public string TransactionStatus { get; set; }
        public string ErrorMessage { get; set; }

        public virtual Accounts SendersAccount { get; set; }

        public virtual Accounts ReceiversAccount { get; set; }
    }
}
