using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.Threading.Tasks;


using Started_App.Library.API;

namespace Started_App.Library.Modules.Token
{
    public class TokenRemoteApi
    {

       


        string tokenUrl = "oauth/token";


        NetworkApi networkAPI;
        IdsXamarinApiContext apiContext;
   


        public TokenRemoteApi()
        {

            apiContext = AbstractApiContext.get("app") as IdsXamarinApiContext;
            networkAPI = new NetworkApi();

		}


        public async Task<string> getClientToken(Dictionary<string, string> tokenDetails){

            string hostUrl = apiContext.getHost("app");
            string connectUrl = hostUrl + tokenUrl; 


            HttpResponseMessage response = await networkAPI.postRequestWithEncode(connectUrl, tokenDetails, null, "");
			var respContent = await response.Content.ReadAsStringAsync();

            return respContent;

		}
    }
}
