using System;
using System.Collections.Generic;
using System.Text;
using J1_S1_01.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace J1_S1_01.Services.Interfaces
{
    interface IAccountService
    {
        Task<ObservableCollection<UserAccounts>> GetUserAccounts();
        Task<bool> Login(string username, string password);
        Task<bool> CreateAccount(UserAccounts userAccounts);
        Task<bool> DeleteAccount(string id);
        Task<bool> UpdateAccount(UserAccounts userAccounts);
    }
}
