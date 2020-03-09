using Fiap.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fiap.App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApiPage : ContentPage
    {
        public ApiPage()
        {
            InitializeComponent();
            BindingContext = new ApiPageViewModel();
        }
    }
}