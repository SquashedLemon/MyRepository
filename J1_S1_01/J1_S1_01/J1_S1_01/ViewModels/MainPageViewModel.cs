using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using J1_S1_01.Models;
using J1_S1_01.Services;
using J1_S1_01.ViewModels.Base;
using J1_S1_01.Views;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace J1_S1_01.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private AccountService _AccountService;
        public ICommand NavigateCreate { protected set; get; }

        private ObservableCollection<UserAccounts> _userAccounts;
        public ObservableCollection<UserAccounts> AccountList
        {
            get => _userAccounts;
            set
            {
                _userAccounts = value;
                OnPropertyChanged();
            }
        }

        private UserAccounts userAccount;
        public UserAccounts UserAccount
        {
            get => userAccount;
            set
            {
                if (userAccount != value)
                {
                    userAccount = value;

                    new Action(async () =>
                    {
                        await HandleItemSelected();
                    }).Invoke();

                    userAccount = null;
                }
            }
        }

        public MainPageViewModel()
        {
            _AccountService = new AccountService();

            var loading = UserDialogs.Instance.Loading("Retrieving data...");

            new Action(async () =>
            {
                

                AccountList = await _AccountService.GetUserAccounts();

            }).Invoke();

            loading.Hide();

            NavigateCreate = new Command(OnNavigateCreate);   
        }

        private async void OnNavigateCreate()
        {
            await App.Current.MainPage.Navigation.PushAsync(new CreateUserPage());
        }

        private async Task HandleItemSelected()
        {
            await App.Current.MainPage.Navigation.PushAsync(new UserDetailPage(userAccount));
        }
    }
}
