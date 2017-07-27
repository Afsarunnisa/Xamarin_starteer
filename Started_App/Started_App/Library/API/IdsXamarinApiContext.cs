using System;
using System.Collections.Generic;


using Started_App;
using Started_App.Library.API.Models;


namespace Started_App.Library.API
{
    public class IdsXamarinApiContext : InMemoryApiContext, ApiContext
    {
        public String CLIENT_ID_PROPERTY = "WAVELABS_CLIENT_ID";
        public String CLIENT_SECRET_PROPERTY = "WAVELABS_CLIENT_SECRET";


        public IdsXamarinApiContext()
        {

            Dictionary<string, string> client = new Dictionary<string, string>();
            client.Add("client_id", "9c750641-48a1-4e86-a042-a66308cdcb2d");
            client.Add("client_secret", "mycartsecret");

            base.setClientCredentials(client);
        }


		override public void setHost(String moduleName, String host)
		{
            base.setHost(moduleName, host);
		}


		override public String getHost(String moduleName)
		{
            // set host in config
			return "http://api.qa1.nbos.in/";
		}

		override public Dictionary<string, string> getClientCredentials()
		{
            return base.getClientCredentials();
		}


        protected void saveModel(String prefName, Object model)
        {
            Started_App.App.Current.Properties[prefName] = model;
        }

        protected Object readModel(String prefName)
        {
            return Started_App.App.Current.Properties[prefName];
        }


        // CLIENT TOKEN set/get
        override public void setClientToken(TokenApiModel tokenApiModel)
        {

            this.saveModel("token.client", tokenApiModel);
            base.setClientToken(tokenApiModel);
        }


        override public TokenApiModel getClientToken()
        {

            TokenApiModel tokenApiModel = base.getClientToken();

            if (tokenApiModel != null)
            {
                return tokenApiModel;
            }

            tokenApiModel = (TokenApiModel)this.readModel("token.client");
            base.setClientToken(tokenApiModel);

            return tokenApiModel;

        }

        override public void setUserToken(String moduleName, TokenApiModel tokenApiModel)
        {
            this.saveModel("token.client", tokenApiModel);
            base.setUserToken(moduleName, tokenApiModel);
        }


        override public TokenApiModel getUserToken(String moduleName)
        {

            TokenApiModel tokenApiModel = base.getClientToken();

            if (tokenApiModel != null)
            {
                return tokenApiModel;
            }

            tokenApiModel = (TokenApiModel)this.readModel("token.user");
            base.setClientToken(tokenApiModel);

            return tokenApiModel;
        }

    }
}
