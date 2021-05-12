using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPSAM.Entities
{
    public class Consultation
    {
        public int ID { get; set; }
        public int IDPacient { get; set; }
        public virtual Pacient Pacient { get; set; }
        public int IDDoctor { get; set; }
        public DateTime Data { get; set; }
        public string Simptome { get; set; }
        public string Diagnostic { get; set; }
        public string Tratament { get; set; }

    }
}
