using MPSAM.Mobile4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MPSAM.Mobile4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdaugareActivitatePage : ContentPage
    {
        private DateTime date;
        private String denumire;
        private string descriere;

        List<Activitate> ListaActivitati;
        DatePicker datePicker = new DatePicker()
        {
            Date = DateTime.Now,
            MinimumDate = DateTime.Now
        };
        Entry denumireEntry = new Entry();
        Entry descriereEntry = new Entry();

        

        public AdaugareActivitatePage(ref List<Activitate> activitati)
        {

            InitializeComponent();
            ListaActivitati = activitati;
            stackLayout.Children.Add(new Label() { Text = "Adaugare activitate noua", FontSize = 24, HorizontalTextAlignment = TextAlignment.Center });
            stackLayout.Children.Add(new Label() { Text = "Data Activitatii",Padding=new Thickness(0,100,0,0) });
            stackLayout.Children.Add(datePicker);
            
            stackLayout.Children.Add(new Label { Text = "Denumire Activitate", Padding = new Thickness(0, 30, 0, 0) });
            stackLayout.Children.Add(denumireEntry);

            stackLayout.Children.Add(new Label { Text = "Descriere Activitate(Optional)",Padding=new Thickness(0,30,0,0) });
            stackLayout.Children.Add(descriereEntry);

            Button btn = new Button() { Text = "Salvare" };
            btn.Clicked += Btn_Clicked;

            stackLayout.Children.Add(btn);
            
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            ListaActivitati.Add(new Activitate() { ID = 0, Data = datePicker.Date, Descriere = descriereEntry.Text, Nume = denumireEntry.Text });
            Navigation.PushAsync(new ActivitatiPage());
            
        }
    }
}