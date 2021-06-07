using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPSAM.Entities
{
    public class ActivityJournal
    {
        public int ID { get; set; }
        public int IDPacient { get; set; }
        public DateTime Data { get; set; }
        public string Activitate { get; set; }
        public string Descriere { get; set; }
    }
}
