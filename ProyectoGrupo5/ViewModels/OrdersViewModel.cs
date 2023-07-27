﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ProyectoGrupo5.Models;
using Xamarin.Forms;
using ProyectoGrupo5.Services;
using ProyectoGrupo5.Resources;
using ProyectoGrupo5.Views;

namespace ProyectoGrupo5.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {
        IService service => DependencyService.Get<IService>();

        public ObservableCollection<Order> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<Order> ItemTapped { get; }

        public OrdersViewModel()
        {
            Title = AppResources.Orders;
            Items = new ObservableCollection<Order>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<Order>(OnItemSelected);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            Items.Clear();
            var items = await service.GetOrdersAsync(Globals.LoggedCustomerId);
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

        async void OnItemSelected(Order item)
        {
            if (item == null) return;

            await Shell.Current.GoToAsync($"{nameof(OrderDetailPage)}" +
                                          $"?{nameof(OrderDetailViewModel.OrderId)}={item.Id}");
        }
    }
}
