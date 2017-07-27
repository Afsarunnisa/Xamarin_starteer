using System;
using Newtonsoft.Json;


namespace Started_App.Library.API.Models
{
    public class SignUpModel
    {
		public string email { get; set; }
		public string password { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string username { get; set; }
		public string clientID { get; set; }


		public SignUpModel()
        {
        }
    }
}
