using ProyectoGrupo5.ViewModels;
using Xamarin.Forms;

namespace ProyectoGrupo5.Views
{
    public partial class OrdersPage : ContentPage
    {
        OrdersViewModel viewModel;

        public OrdersPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new OrdersViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }

    }
}
