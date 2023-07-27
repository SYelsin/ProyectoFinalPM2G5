using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ProyectoGrupo5.Models;
using Xamarin.Forms;
using ProyectoGrupo5.Services;
using ProyectoGrupo5.Resources;
using ProyectoGrupo5.Views;

namespace ProyectoGrupo5.ViewModels
{
    [QueryProperty(nameof(ProductId), nameof(ProductId))]
    public class RatingsViewModel : BaseViewModel
    {
        IService service => DependencyService.Get<IService>();

        public ObservableCollection<Rating> Items { get; }

        public ICommand LoadItemsCommand { get; }
        public ICommand AddRatingCommand { get; }

        private string productId;
        public string ProductId
        {
            get => productId;
            set => productId = value;
        }

        public RatingsViewModel()
        {
            Title = AppResources.Ratings;
            Items = new ObservableCollection<Rating>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddRatingCommand = new Command(async () => await OnAddRating());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            Items.Clear();
            var items = await service.GetRatingsAsync(productId);

            foreach (var item in items)
                Items.Add(item);

            IsBusy = false;
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task OnAddRating()
        {
            await Shell.Current.GoToAsync($"{nameof(NewRatingPage)}" +
                                          $"?{nameof(NewRatingViewModel.ProductId)}={productId}");
        }

    }
}
