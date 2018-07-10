using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace J1_S1_01.Models
{
    public class Id
    {
        [JsonProperty(PropertyName = "$oid")]
        public string _id { get; set; }
    }

    public class UserAccounts
    {
        public Id _Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
