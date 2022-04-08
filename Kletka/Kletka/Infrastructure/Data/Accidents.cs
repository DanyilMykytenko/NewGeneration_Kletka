using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Infrastructure.Data
{
    public class Accidents : IEntity
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public string Accident { get; set; }
        public DateTime AccidentTime { get; set; }
        public bool AccidentStatus { get; set; }
        public string AccidentComment { get; set; }
        public virtual Users Users { get; set; }
    }
}
