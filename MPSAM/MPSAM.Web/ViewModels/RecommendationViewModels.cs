using MPSAM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPSAM.Web.ViewModels
{
    public class NewRecommendation
    {
        public int IDPacient { get; set; }
        public int IDDoctor { get; set; }
        public DateTime Data { get; set; }
        public string Text { get; set; }
        public Pacient Pacient { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}