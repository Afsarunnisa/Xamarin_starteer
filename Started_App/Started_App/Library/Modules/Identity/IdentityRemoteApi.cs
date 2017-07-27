using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;

using Started_App.Library.API;
using Started_App.Library.API.Models;


namespace Started_App.Library.Modules.Identity
{
    public class IdentityRemoteApi
    {

		string baseIdentityUrl = "api/identity/v0";
		string baseCoreUrl = "api/core/v0";
		string tokenUrl = "oauth/token";



		string loginUrl = "";
		string signupUrl = "";
		string socailConnectUrl = "";
		string authorizeUrl = "";
		string profileUrl = "";
		string forgotUrl = "";
		string changePasswordUrl = "";
		string logoutUrl = "";
		string socialLoginUrl = "";

		string getModulesUrl = "";

		string connectService = "";
		string authorizeService = "";
		string loginService = "";

		string accountKitUrl = "";

		NetworkApi networkAPI;
		IdsXamarinApiContext apiContext;

        string clientToken;

		public IdentityRemoteApi()
        {
			apiContext = AbstractApiContext.get("app") as IdsXamarinApiContext;
			networkAPI = new NetworkApi();

            loginUrl = baseIdentityUrl + "/auth/login";
			signupUrl = baseIdentityUrl + "/users/signup";



            TokenApiModel clientTokenModel = apiContext.getClientToken() as TokenApiModel;
            clientToken = clientTokenModel.access_token;



		}


        public async Task<string> login(LoginModel loginDetails)
		{

			string hostUrl = apiContext.getHost("app");
			string connectUrl = hostUrl + loginUrl;

   //         Dictionary<string, string> details = new Dictionary<string, string>();

   //         details.Add("username", loginDetails.username);
			//details.Add("password", loginDetails.password);
			//details.Add("client_id", loginDetails.clientID);



			HttpResponseMessage response = await networkAPI.postRequest(connectUrl, loginDetails, null, clientToken);

			//HttpResponseMessage response = await networkAPI.postRequestWithEncode(connectUrl, null, null, clientToken);
			var respContent = await response.Content.ReadAsStringAsync();

			return respContent;

		}

        public async Task<string> signUp(SignUpModel signUpDetails)
		{

			string hostUrl = apiContext.getHost("app");
            string connectUrl = hostUrl + signupUrl;

			
			HttpResponseMessage response = await networkAPI.postRequest(connectUrl, signUpDetails, null, clientToken);

			//HttpResponseMessage response = await networkAPI.postRequestWithEncode(connectUrl, null, null, clientToken);
			var respContent = await response.Content.ReadAsStringAsync();

			return respContent;

		}



    }
}
