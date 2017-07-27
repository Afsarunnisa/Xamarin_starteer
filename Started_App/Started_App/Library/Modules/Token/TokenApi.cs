using System;
using System.Collections.Generic;
using System.Diagnostics;


using Newtonsoft.Json;

using Started_App.Library.API;
using Started_App.Library.API.Models;

namespace Started_App.Library.Modules.Token
{
    public class TokenApi : NetworkApi
    {
        public TokenApi()
        {
            //base();
			setModuleName("token");
            setRemoteApiClass(typeof(TokenRemoteApi));
        }


        public async void getClientToken(){
            
            TokenRemoteApi remoteAPI = new TokenRemoteApi();
            IdsXamarinApiContext apiContext = AbstractApiContext.get("app") as IdsXamarinApiContext;

            Dictionary<string, string> clientCredentials = apiContext.getClientCredentials();

            Dictionary<string, string> tokenDetails = new Dictionary<string, string>();

            tokenDetails.Add("client_id",clientCredentials["client_id"]);
			tokenDetails.Add("client_secret", clientCredentials["client_secret"]);
			tokenDetails.Add("grant_type", "client_credentials");
			tokenDetails.Add("scope", "");


            var tokenValue = await remoteAPI.getClientToken(tokenDetails);

            TokenApiModel mytoken = JsonConvert.DeserializeObject<TokenApiModel>(tokenValue);
            apiContext.setClientToken(mytoken);

            Debug.WriteLine("mytoken value {0}", mytoken.access_token);


			Debug.WriteLine("tokenValue {0}", tokenValue);

		}
    }
}
