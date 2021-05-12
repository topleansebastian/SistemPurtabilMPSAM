using MPSAM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPSAM.Web.ViewModels
{
    public class ConsultationViewModels
    {
        public class ConsultationSearchViewModel
        {
            public List<Consultation> Consultations { get; set; }
            public string WordToBeSearched { get; set; }
            public Pagination Pagination { get; set; }
        }
    }
}