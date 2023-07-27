using ProyectoGrupo5.ViewModels;
using Xamarin.Forms;

namespace ProyectoGrupo5.Views
{
    public partial class RatingsPage : ContentPage
    {
        RatingsViewModel viewModel;

        public RatingsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RatingsViewModel(); 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }

    }
}
