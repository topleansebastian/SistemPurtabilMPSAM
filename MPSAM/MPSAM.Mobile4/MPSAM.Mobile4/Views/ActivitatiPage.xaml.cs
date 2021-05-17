using MPSAM.Mobile4.Models;
using MPSAM.Mobile4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;



using Xamarin.Plugin.Calendar.Models;

namespace MPSAM.Mobile4.Views
{



    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivitatiPage : ContentPage
    {
        MockDataStore mock = MockDataStore.Instance;



        public EventCollection Events { get; set; } = new EventCollection();

        public String MyProperty = "Hi im a labl";
        public ActivitatiPage()
        {
            InitializeComponent();

            Dictionary<DateTime, List<EventModel>> dict = new Dictionary<DateTime, List<EventModel>>();

            foreach (Activitate a in GetActivitati())
            {
                if (dict.ContainsKey(a.Data))
                {
                    dict[a.Data].Add(new EventModel() { ID = a.ID, Nume = a.Nume, Descriere = a.Descriere, Data = a.Data });
                }
                else
                {
                    dict[a.Data] = new List<EventModel>() { new EventModel() { ID = a.ID, Nume = a.Nume, Descriere = a.Descriere, Data = a.Data } };
                }
            }

            foreach (DateTime date in dict.Keys)
            {
                Events.Add(date, dict[date]);
            }

            Events = Events;
            Title = "Activitati";
            CalendarControl.Events = Events;

            var activitati = mock.activitati;


          


        }
        public List<Activitate> GetActivitati()
        {
            return mock.activitati;
        }

        internal class EventModel
        {
            public int ID { get; set; }
            public String Nume { get; set; }
            public String Descriere { get; set; }
            public DateTime Data { get; set; }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdaugareActivitatePage(ref mock.activitati));
        }
    }




}
