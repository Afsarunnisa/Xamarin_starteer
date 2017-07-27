using System;
namespace Started_App.Library.API.Models
{
    public class LoginModel
    {

		public string username { get; set; }
		public string password { get; set; }
		public string clientID { get; set; }

        public LoginModel()
        {
        }
    }
}
