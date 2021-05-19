using MPSAM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPSAM.Web.ViewModels
{
    public class ConsultationViewModels
    {
        public class EditConsultationViewModel
        {
            public int ID { get; set; }
            public int IDPacient { get; set; }
            public Pacient Pacient { get; set; }
            public string CNP { get; set; }
            public int IDDoctor { get; set; }
            public DateTime Data { get; set; }
            public string Simptome { get; set; }
            public string Diagnostic { get; set; }
            public string Tratament { get; set; }
            public List<Pacient> Pacients { get; set; }
            public List<Doctor> Doctors { get; set; }
        }
        public class ConsultationSearchViewModel
        {
            public List<Consultation> Consultations { get; set; }
            public string WordToBeSearched { get; set; }
            public Pagination Pagination { get; set; }
        }
        public class NewConsultationViewModel
        {
            public int IDPacient { get; set; }
            public Pacient Pacient { get; set; }
            public string CNP { get; set; }
            public int IDDoctor { get; set; }
            public DateTime Data { get; set; }
            public string Simptome { get; set; }
            public string Diagnostic { get; set; }
            public string Tratament { get; set; }
        }
        public class InfoConsultationViewModel
        {
            public Pacient Pacient { get; set; }
            public Consultation Consultation { get; set; }
            public Doctor Doctor { get; set; }
        }
    }
}