using System;
using Newtonsoft.Json;

namespace Started_App.Library.API.Models
{
    public class NewMemberApiModel
    {


		[JsonProperty("member")]
		public MemberApiModel member { get; set; }

		[JsonProperty("token")]
		public TokenApiModel token { get; set; }

		public NewMemberApiModel()
        {
        }
    }
}
