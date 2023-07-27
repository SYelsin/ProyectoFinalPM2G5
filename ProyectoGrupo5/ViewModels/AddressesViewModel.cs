using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ProyectoGrupo5.Models;
using Xamarin.Forms;
using ProyectoGrupo5.Services;
using ProyectoGrupo5.Resources;
using ProyectoGrupo5.Views;

namespace ProyectoGrupo5.ViewModels
{
    public class AddressesViewModel : BaseViewModel
    {
        IService serviceAddress => DependencyService.Get<IService>();

        public ObservableCollection<Address> Items { get; }

        public Command LoadItemsCommand { get; }
        public Command<Address> ItemSelectedCommand { get; }
        public Command AddTappedCommand { get; }

        public AddressesViewModel()
        {
            Title = AppResources.Addresses;

            Items = new ObservableCollection<Address>();
            LoadItemsCommand = new Command(async () => await LoadItems());
            ItemSelectedCommand = new Command<Address>(OnItemSelected);
            AddTappedCommand = new Command(OnAddTapped);
        }

        private async Task LoadItems()
        {
            IsBusy = true;

            Items.Clear();
            var items = await serviceAddress.GetAddressesAsync(Globals.LoggedCustomerId);
            foreach (var item in items)
            {
                Items.Add(item);
            }

            IsBusy = false;
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        private async void OnItemSelected(Address item)
        {
            if (item == null) return;

            await Shell.Current.GoToAsync($"{nameof(AddressDetailPage)}" +
                                          $"?{nameof(AddressDetailViewModel.AddressId)}={item.Id}");
        }

        private async void OnAddTapped()
        {
            await Shell.Current.GoToAsync($"{nameof(AddressDetailPage)}");
        }

    }
}
