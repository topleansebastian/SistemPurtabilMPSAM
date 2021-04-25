using MPSAM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPSAM.Web.ViewModels
{
    public class AdministratorLoginViewModels
    {
        public string Utilizator { get; set; }
        public string Password { get; set; }
    }
    public class DoctorSearchViewModel
    {
        public List<Doctor> Doctors { get; set; }
        public string WordToBeSearched { get; set; }
        public Pagination Pagination { get; set; }
    }
    public class NewDoctorViewModel
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string CodParafa { get; set; }
        public string Cabinet { get; set; }
        public string Parola { get; set; }
    }
}