using System;
using System.Collections.Generic;
using System.Text;
using J1_S1_01.Models;
using J1_S1_01.Services.Interfaces;
using J1_S1_01.Helpers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace J1_S1_01.Services
{
    public class AccountService : IAccountService
    {
        private HttpClient httpClient;
        private ObservableCollection<UserAccounts> userAccounts;

        public async Task<bool> CreateAccount(UserAccounts userAccounts)
        {
            httpClient = new HttpClient();

            var serializedJson = JsonConvert.SerializeObject(userAccounts);

            var content = new StringContent(serializedJson, Encoding.UTF8, "application/json");

            var result = await httpClient.PostAsync(Common.GetAddressAPI("UserAccounts"), content);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public async Task<bool> DeleteAccount(string id)
        {
            httpClient = new HttpClient();

            var result = await httpClient.DeleteAsync(Common.GetAddressSingle("UserAccounts", id));

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public async Task<ObservableCollection<UserAccounts>> GetUserAccounts()
        {   
            httpClient = new HttpClient();
            
            var response = await httpClient.GetStringAsync(Common.GetAddressAPI("UserAccounts"));

            var deserializedJson = JsonConvert.DeserializeObject<ObservableCollection<UserAccounts>>(response);

            userAccounts = deserializedJson;

            return userAccounts;
        }

        public async Task<bool> Login(string username, string password)
        {
            httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(Common.GetAddressSingle("UserAccounts", username, password));

            var deserializedJson = JsonConvert.DeserializeObject<List<UserAccounts>>(response);

            List<UserAccounts> listAccounts = deserializedJson;

            if (listAccounts != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateAccount(UserAccounts userAccounts)
        {
            httpClient = new HttpClient();

            var serializedJson = JsonConvert.SerializeObject(userAccounts);

            var content = new StringContent(serializedJson, Encoding.UTF8, "application/json");

            var result = await httpClient.PutAsync(Common.GetAddressSingle("UserAccounts", userAccounts._Id._id), content);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }
    }
}