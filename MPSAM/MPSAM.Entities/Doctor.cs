using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPSAM.Entities
{
    public class Doctor
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string CodParafa { get; set; }
        public string Cabinet { get; set; }
        public string Parola { get; set; }
        public List<Pacient> Pacienti { get; set; }
    }
}
