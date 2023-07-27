using ProyectoGrupo5.ViewModels;
using Xamarin.Forms;

namespace ProyectoGrupo5.Views
{
    public partial class CartPage : ContentPage
    {
        CartViewModel viewModel;

        public CartPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CartViewModel();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }

    }
}
