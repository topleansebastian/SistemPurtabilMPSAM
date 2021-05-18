using MPSAM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPSAM.Web.ViewModels
{
    public class PacientLoginViewModels
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class PacientSearchViewModel
    {
        public List<Pacient> Pacients { get; set; }
        public string WordToBeSearched { get; set; }
        public Pagination Pagination { get; set; }
    }
    public class NewPacientViewModel
    {
        public int IDMedic { get; set; }
        public virtual Doctor Medic { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNP { get; set; }
        public string Sex { get; set; }
        public int Varsta { get; set; }
        public string DataNasterii { get; set; }
        public string Adresa { get; set; }
        public string Localitate { get; set; }
        public string Judet { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Ocupatie { get; set; }
        public string LocDeMunca { get; set; }
        public string GrupSanguin { get; set; }
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
        public string Parola { get; set; }
    }
    public class EditPacientViewModel
    {
        public int ID { get; set; }
        public int IDMedic { get; set; }
        public virtual Doctor Medic { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNP { get; set; }
        public string Sex { get; set; }
        public int Varsta { get; set; }
        public string DataNasterii { get; set; }
        public string Adresa { get; set; }
        public string Localitate { get; set; }
        public string Judet { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Ocupatie { get; set; }
        public string LocDeMunca { get; set; }
        public string GrupSanguin { get; set; }
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
        public string Parola { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
    public class InfoPacientViewModel
    {
        public Pacient Pacient { get; set; }
        public Doctor Doctor { get; set; }
        public List<Consultation> Consultations { get; set; }
        public Doctor ConsultDoctor { get; set; }
        public List<Recommendation> Recommendations { get; set; }
        public List<ActivityJournal> ActivityJournals { get; set; }
    }
    public class SelectedPacientsAndDoctors
    {
        public int IDPacient { get; set; }
        public IEnumerable<Pacient> Pacients { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
    
}