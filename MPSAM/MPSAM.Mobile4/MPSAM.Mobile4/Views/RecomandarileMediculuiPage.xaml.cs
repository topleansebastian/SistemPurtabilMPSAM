using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MPSAM.Mobile4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecomandarileMediculuiPage : ContentPage
    {
        public RecomandarileMediculuiPage()
        {
            InitializeComponent();
            Title = "Recomandarile Medicului";
            var data = GetData();
            DataGrid.ColumnDefinitions = new ColumnDefinitionCollection()
            {
                new ColumnDefinition(){Width=30 },
                new ColumnDefinition()
            };
            DataGrid.RowDefinitions = new RowDefinitionCollection();

            for (int i=0;i<data.Count;i++)
            {
                DataGrid.RowDefinitions.Add(new RowDefinition());

                DataGrid.Children.Add(new BoxView
                {
                },0,i);
                DataGrid.Children.Add(new Label
                {
                    Text = $"{i}",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                },0,i);

                // This BoxView and Label are in row 0 and column 1, which are specified as arguments
                // to the Add method.
                DataGrid.Children.Add(new BoxView
                {
                }, 1, i);
                DataGrid.Children.Add(new Label
                {
                    Text = data[i],
                    VerticalOptions = LayoutOptions.Center,
                }, 1, i);

            }
            
        }

        private List<String> GetData()
        {
            List<String> data = new List<string>();

            data.Add("Recomandare1");
            data.Add("Recomandare2");
            data.Add("Recomandare3");
            data.Add("Recomandare4");
            data.Add("Recomandare5");
            data.Add("Recomandare6");
            data.Add("Recomandare7");
            data.Add("Recomandare8");
            data.Add("Recomandare9");
            return data;

        
        }
    }
}