using System;
using System.Collections.Generic;



using Started_App.Library.API.Models;

namespace Started_App.Library.API
{
    public interface ApiContext
    {
		String getName();
		
        void setHost(String moduleName, String host);
        String getHost(String moduleName);


        void setClientCredentials(Dictionary<string, string> map);
		void setClientToken(TokenApiModel tokenApiModel);

		Dictionary<string, string> getClientCredentials();
		TokenApiModel getClientToken();

		void setUserToken(String moduleName, TokenApiModel tokenApiModel);
		TokenApiModel getUserToken(String moduleName);
       

	}
}
