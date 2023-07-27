using ProyectoGrupo5.ViewModels;
using Xamarin.Forms;

namespace ProyectoGrupo5.Views
{
    public partial class ProductsPage : ContentPage
    {
        ProductsViewModel viewModel;

        public ProductsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ProductsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }

    }
}
