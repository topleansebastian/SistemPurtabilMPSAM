using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPSAM.Entities
{
    public class Alarm
    {
        public int ID { get; set; }
        public int IDPacient { get; set; }
        public string ValoareVizata { get; set; }
        public decimal LimitaInferioara { get; set; }
        public decimal LimitaSuperioara { get; set; }
        public string Mesaj { get; set; }
    }
}
