﻿using ProyectoGrupo5.Models;
using System.Threading.Tasks;
using Xamarin.Forms;
using ProyectoGrupo5.Services;
using ProyectoGrupo5.Resources;

namespace ProyectoGrupo5.ViewModels
{
    public class AccountDetailsViewModel : BaseViewModel
    {
        IService service => DependencyService.Get<IService>();

        public Command SaveCommand { get; }
        public Command EditPhotoCommand { get; }

        private Customer customer;

        private string image;
        public string Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        private string fullName;
        public string FullName
        {
            get => fullName;
            set => SetProperty(ref fullName, value);
        }

        private string username;
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        private string email;
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public AccountDetailsViewModel()
        {
            LoadCustomer(Globals.LoggedCustomerId);

            Title = AppResources.AccountDetails;

            SaveCommand = new Command(async () => await OnSaveTapped());

            EditPhotoCommand = new Command(async () => {
                await Shell.Current.DisplayAlert(AppResources.Info, AppResources.EditPhotoTapped, AppResources.OK);
            });
        }

        private async void LoadCustomer(string id)
        {
            customer = await service.GetCustomerAsync(id);
            Image = customer.Image;
            FullName = customer.FullName;
            Username = customer.Username;
            Email = customer.Email;
        }

        private async Task OnSaveTapped()
        {
            var newCustomer = new Customer
            {
                Id = customer.Id,
                Addresses = customer.Addresses,
                FullName = fullName,
                Username = username,
                Email = email,
            };

            await service.UpdateCustomerAsync(newCustomer);

            await Shell.Current.GoToAsync("..");
        }

    }
}
