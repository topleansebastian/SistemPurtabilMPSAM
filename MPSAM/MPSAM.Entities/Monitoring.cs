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
        public int Temperatura { get; set; }
        public int Umiditate { get; set; }
        public int Puls { get; set; }
        public string Ecg { get; set; }
        public DateTime Data { get; set; }
    }
}
