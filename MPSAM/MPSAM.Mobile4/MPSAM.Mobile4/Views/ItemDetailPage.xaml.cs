using MPSAM.Mobile4.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MPSAM.Mobile4.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}