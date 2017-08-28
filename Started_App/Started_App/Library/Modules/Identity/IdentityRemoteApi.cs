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
		string userToken;

		public IdentityRemoteApi()
        {
			apiContext = AbstractApiContext.get("app") as IdsXamarinApiContext;
			networkAPI = new NetworkApi();

            loginUrl = baseIdentityUrl + "/auth/login";
			signupUrl = baseIdentityUrl + "/users/signup";
            profileUrl = baseIdentityUrl + "/users/";

            TokenApiModel clientTokenModel = apiContext.getClientToken() as TokenApiModel;
            clientToken = clientTokenModel.access_token;

           
		}


        public async Task<string> login(LoginModel loginDetails)
		{

			string hostUrl = apiContext.getHost("app");
			string connectUrl = hostUrl + loginUrl;


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

        public async Task<string> GetProfile(int userId)
        {

			TokenApiModel userTokenModel = apiContext.getUserToken("token.user") as TokenApiModel;
			userToken = userTokenModel.access_token;


            Debug.WriteLine("userToken {0}", userToken);

			string hostUrl = apiContext.getHost("app");
            string connectUrl = hostUrl + profileUrl + userId;

            HttpResponseMessage response = await networkAPI.getRequest(connectUrl, null, null, userToken);

			//HttpResponseMessage response = await networkAPI.postRequestWithEncode(connectUrl, null, null, clientToken);
			var respContent = await response.Content.ReadAsStringAsync();

            Debug.WriteLine("respContent {0}",respContent);


			return respContent;
        }

        public async Task<string> UpdateProfile(Dictionary<string, string> userDeatils, int userId)
        {
			TokenApiModel userTokenModel = apiContext.getUserToken("token.user") as TokenApiModel;
			userToken = userTokenModel.access_token;


			Debug.WriteLine("userToken {0}", userToken);

			string hostUrl = apiContext.getHost("app");
			string connectUrl = hostUrl + profileUrl + userId;

			Debug.WriteLine("connectUrl {0}", connectUrl);


            HttpResponseMessage response = await networkAPI.putRequest(connectUrl, userDeatils, null, userToken);

            var respContent = await response.Content.ReadAsStringAsync();

			Debug.WriteLine("respContent {0}", respContent);

			return respContent;
        }



	}
}
