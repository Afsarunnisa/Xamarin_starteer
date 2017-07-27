using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Started_App.Library.API.Models
{
    public class MemberApiModel
    {

	


		[JsonProperty("description")]
		public string description { get; set; }

		[JsonProperty("email")]
		public string email { get; set; }

		[JsonProperty("emailConnects")]
		public List<String> emailConnects { get; set; }

		[JsonProperty("firstName")]
		public string firstName { get; set; }


		[JsonProperty("id")]
		public int id { get; set; }


		[JsonProperty("isExternal")]
		public bool isExternal { get; set; }


		[JsonProperty("jsonAttributes")]
		public string jsonAttributes { get; set; }


		[JsonProperty("lastName")]
		public string lastName { get; set; }
		
        [JsonProperty("phone")]
		public string phone { get; set; }


		[JsonProperty("socialAccounts")]
        public List<String> socialAccounts { get; set; }


		[JsonProperty("uuid")]
		public string uuid { get; set; }


		public MemberApiModel()
        {
        }
    }
}
