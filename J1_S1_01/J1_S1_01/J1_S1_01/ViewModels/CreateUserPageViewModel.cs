using System;
using System.Collections.Generic;
using System.Text;
using J1_S1_01.Models;
using J1_S1_01.ViewModels.Base;
using J1_S1_01.Services;
using J1_S1_01.Views;
using System.Windows.Input;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace J1_S1_01.ViewModels
{
    public class CreateUserPageViewModel : BaseViewModel
    {
        private AccountService _AccountService;
        private UserAccounts userAccount;

        public ICommand CreateCommand { protected set; get; }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public CreateUserPageViewModel()
        {
            _AccountService = new AccountService();

            CreateCommand = new Command(OnCreateCommand);
        }

        private async void OnCreateCommand()
        {
            userAccount = new UserAccounts() { _Id = new Id { _id = ""}, Username = _username, Password = _password };

            var loading = UserDialogs.Instance.Loading("Deleting data...");

            await _AccountService.CreateAccount(userAccount);

            loading.Hide();

            App.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}
