using MPSAM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPSAM.Web.ViewModels
{
    public class NewRecommendation
    {
        public Pacient Pacient { get; set; }
        public DateTime Data { get; set; }
        public string Text { get; set; }
    }
}