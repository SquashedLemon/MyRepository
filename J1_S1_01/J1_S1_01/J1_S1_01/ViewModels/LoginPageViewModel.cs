using System;
using System.Collections.Generic;
using System.Text;
using J1_S1_01.ViewModels.Base;
using J1_S1_01.Services;
using J1_S1_01.Models;
using J1_S1_01.Views;
using System.Windows.Input;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace J1_S1_01.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private AccountService _AccountService;

        public ICommand LoginCommand { protected set; get; }

        private List<UserAccounts> _userAccounts;
        public List<UserAccounts> AccountList
        {
            get => _userAccounts;
            set
            {
                _userAccounts = value;
                OnPropertyChanged();
            }
        }

        private UserAccounts _Account;
        public UserAccounts Account
        {
            get => _Account;
            set
            {
                _Account = value;
                OnPropertyChanged("Account");
            }
        }

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

        public LoginPageViewModel()
        {
            _AccountService = new AccountService();

            LoginCommand = new Command(OnLogin);
        }

        private void OnLogin()
        {
            bool isLogged = false;

            var loading = UserDialogs.Instance.Loading("Authenticating...");

            new Action(async () =>
            {
                isLogged = await _AccountService.Login(_username, _password);

                loading.Hide();

                if (isLogged)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Successfully logged in", "OK");
                    App.Current.MainPage = new NavigationPage(new MainPage());
                }
                else
                    await App.Current.MainPage.DisplayAlert("Alert", "Invalid!", "OK");
            }).Invoke();
        }
    }
}
