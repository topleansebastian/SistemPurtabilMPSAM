using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPSAM.Entities
{
    public class Recommendation
    {
        public int ID { get; set; }
        public int IDPacient { get; set; }
        public int IDDoctor { get; set; }
        public DateTime Data { get; set; }
        public string Text { get; set; }
    }
}
