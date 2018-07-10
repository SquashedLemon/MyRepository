using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using J1_S1_01.Models;
using J1_S1_01.Services;
using J1_S1_01.ViewModels.Base;
using J1_S1_01.Views;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace J1_S1_01.ViewModels
{
    public class UserDetailPageViewModel : BaseViewModel
    {
        private AccountService _AccountService;
        private UserAccounts userAccount;
        public ICommand UpdateCommand { protected set; get; }
        public ICommand DeleteCommand { protected set; get; }

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

        public UserDetailPageViewModel(UserAccounts userAccount)
        {
            _AccountService = new AccountService();
            this.userAccount = userAccount;

            _username = this.userAccount.Username;
            _password = this.userAccount.Password;

            UpdateCommand = new Command(OnUpdateCommand);
            DeleteCommand = new Command(OnDeleteCommand);
        }

        private async void OnUpdateCommand()
        {
            var loading = UserDialogs.Instance.Loading("Updating...");

            this.userAccount.Username = Username;
            this.userAccount.Password = Password;

            bool result = false;

            result = await _AccountService.UpdateAccount(this.userAccount);

            loading.Hide();

            if (result)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Successfully updated.", "OK");
                App.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
                await App.Current.MainPage.DisplayAlert("Alert", "Failed to update", "OK");
        }

        private void OnDeleteCommand()
        {
            new Action(async () =>
            {
                var loading = UserDialogs.Instance.Loading("Updating...");

                bool result = false;

                result = await _AccountService.DeleteAccount(this.userAccount._Id._id);

                loading.Hide();

                if (result)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Entry deleted", "OK");
                    App.Current.MainPage = new NavigationPage(new MainPage());
                }
                else
                    await App.Current.MainPage.DisplayAlert("Alert", "Failed to delete", "OK");
            }).Invoke();
        }
    }
}
