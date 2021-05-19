using MPSAM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPSAM.Web.ViewModels
{
    public class ActivityViewModels
    {
        public class NewActivity
        {
            public int ID { get; set; }
            public int IDPacient { get; set; }
            public DateTime Data { get; set; }
            public string Activitate { get; set; }
            public Pacient Pacient { get; set; }
        }
    }
}