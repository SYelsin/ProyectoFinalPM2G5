using ProyectoGrupo5.DataStores.MockDataStore;
using ProyectoGrupo5.Services;
using Xamarin.Forms;

namespace ProyectoGrupo5
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.RegisterSingleton(new BannerDataStore());
            DependencyService.RegisterSingleton(new CategoryDataStore());
            DependencyService.RegisterSingleton(new CustomerDataStore());
            DependencyService.RegisterSingleton(new AddressDataStore());
            DependencyService.RegisterSingleton(new RatingDataStore());
            DependencyService.RegisterSingleton(new FavoriteDataStore());
            DependencyService.RegisterSingleton(new CartItemDataStore());
            DependencyService.RegisterSingleton(new ProductDataStore());
            DependencyService.RegisterSingleton(new OrderItemDataStore());
            DependencyService.RegisterSingleton(new OrderDataStore());
            DependencyService.RegisterSingleton(new VariantDataStore());

            DependencyService.Register<IService, MockService>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
