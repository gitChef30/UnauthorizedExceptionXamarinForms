using System.ComponentModel;
using Xamarin.Forms;

namespace UnauthorizedException
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = new ViewModels.ViewModel();
        }
    }
}
