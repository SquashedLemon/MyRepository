using System;
using System.Collections.Generic;
using System.Text;
using J1_S1_01.Models;

namespace J1_S1_01.Helpers
{
    public static class Common
    {
        private static String DB_NAME = "dbtokenizer";
        private static String API_KEY = "QSoOU8_tylcat2L_KytpjsgMqTsvNlQh";
        private static StringBuilder strBuilder;

        public static String GetAddressAPI(string collectionName)
        {
            String baseUrl = $"https://api.mlab.com/api/1/databases/{DB_NAME}/collections/{collectionName}";

            strBuilder = new StringBuilder(baseUrl);
            strBuilder.Append("?apiKey=" + API_KEY);

            return strBuilder.ToString();
        }

        public static String GetAddressSingle(string collectionName, string id)
        {
            String baseUrl = $"https://api.mlab.com/api/1/databases/{DB_NAME}/collections/{collectionName}";

            strBuilder = new StringBuilder(baseUrl);
            strBuilder.Append("/" + id);
            strBuilder.Append("?apiKey=" + API_KEY);

            return strBuilder.ToString();
        }

        public static String GetAddressSingle(string collectionName, UserAccounts userAccounts)
        {
            String baseUrl = $"https://api.mlab.com/api/1/databases/{DB_NAME}/collections/{collectionName}";

            strBuilder = new StringBuilder(baseUrl);
            strBuilder.Append("/" + userAccounts._Id._id);
            strBuilder.Append("?apiKey=" + API_KEY);

            return strBuilder.ToString();
        }

        public static String GetAddressSingle(string collectionName, string username, string password)
        {
            String baseUrl = $"https://api.mlab.com/api/1/databases/{DB_NAME}/collections/{collectionName}";

            strBuilder = new StringBuilder(baseUrl);
            strBuilder.Append("?q={'Username':'" + username + "', 'Password':'" + password + "'}");
            strBuilder.Append("&apiKey=" + API_KEY);

            return strBuilder.ToString();
        }
    }
}