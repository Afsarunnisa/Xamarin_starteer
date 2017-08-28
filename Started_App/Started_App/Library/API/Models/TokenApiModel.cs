using System;
using Newtonsoft.Json;

namespace Started_App.Library.API.Models
{
    public class TokenApiModel
    {

		[JsonProperty("access_token")]
		public string access_token { get; set; }

		[JsonProperty("expires_in")]
		public string expires_in { get; set; }

		[JsonProperty("refresh_token")]
		public string refresh_token { get; set; }

		[JsonProperty("scope")]
		public string scope { get; set; }

		[JsonProperty("token_type")]
		public string token_type { get; set; }


		public TokenApiModel()
        {
        }
    }
}