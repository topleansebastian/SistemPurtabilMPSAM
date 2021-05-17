using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPSAM.Entities
{
    public class Monitoring
    {
        public int ID { get; set; }
        public int IDPacient { get; set; }
        public decimal Pr { get; set; }
        public decimal Qt { get; set; }
        public decimal Temperatura { get; set; }
        public int Puls { get; set; }
        public DateTime Data { get; set; }
    }
}
