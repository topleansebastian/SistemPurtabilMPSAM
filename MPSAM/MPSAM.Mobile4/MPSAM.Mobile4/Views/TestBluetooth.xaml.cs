using MPSAM.Mobile4.Models;
using MPSAM.Mobile4.Services;
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
    public partial class TestBluetooth : ContentPage
    {
        StackLayout layout;
        public TestBluetooth()
        {
            InitializeComponent();

            var service = DependencyService.Get<IAndroidService>();
            var service2 = DependencyService.Get<IAndroidEventReceiver>();

            service.NewDataGot += Service_NewData;


            //service2.ButtonStateChanged("Hi", null);

            
        }

        private void Service_NewData(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                MainLayout.Children.Add(new Label() { Text = sender as String, TextColor=Color.Red });
            }
            );
    
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
           // AndroidEventReceiver.Instance.FireEvent("Hi");
        }
    }
}