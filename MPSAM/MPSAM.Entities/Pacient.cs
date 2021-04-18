using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPSAM.Entities
{
    public class Pacient
    {
        public int ID { get; set; }
        public int IDMedic { get; set; }
        public virtual Medic Medic { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNP { get; set; }
        public string Sex { get; set; }
        public int Varsta { get; set; }
        public DateTime DataNasterii { get; set; }
        public string Adresa { get; set; }
        public string Localitate { get; set; }
        public string Judet { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Ocupatie { get; set; }
        public string LocDeMunca { get; set; }
        public string RH { get; set; }
        public string Alergii { get; set; }
        public string Inaltime { get; set; }
        public string Greutate { get; set; }
        public string TegumenteMucoase { get; set; }
        public string TesutSubcutanat { get; set; }
        public string Ganglioni { get; set; }
        public string AntecedenteFiziologice { get; set; }
        public string AntecedentePatologice { get; set; }
        public string ConditiiMediu { get; set; }
        public string Internari { get; set; }
        public string MotiveInternari { get; set; }
        public string Zgomot { get; set; }
        public string Suflu { get; set; }
        public string Frecventa { get; set; }
        public string Aritmii { get; set; }
        public string Username { get; set; }
        public string Parola { get; set; }
    }
}
