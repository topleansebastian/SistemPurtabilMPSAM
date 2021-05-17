using MPSAM.Mobile4.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Plugin.Calendar.Models;

namespace MPSAM.Mobile4.ViewModels
{
    public class ActivitatiViewModel:BaseViewModel
    {

        public Label label;
        public EventCollection Events { get; set; }
        public String MyText { get; } = "My text";

        public Grid grid = new Grid();

        
        public ActivitatiViewModel()
        {


        }


        

        
    }

   
}
