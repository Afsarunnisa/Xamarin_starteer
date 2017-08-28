using System;
using System.Collections.Generic;
using System.Diagnostics;

using Started_App.Library.API.Models;


namespace Started_App.Library.API
{
    public class InMemoryApiContext : AbstractApiContext
    {

        Dictionary<string, Object> store = new Dictionary<string, Object>();
		Dictionary<string, string> hosts = new Dictionary<string, string>();
		Dictionary<string, TokenApiModel> tokens = new Dictionary<string, TokenApiModel>();



		public InMemoryApiContext()
        {
        }

		public InMemoryApiContext(String name)
		{
            //base.name;
        }

        override public String getName()
		{
			return name;
		}


	    override public void setClientCredentials(Dictionary<string, string> map)
		{
			store.Add("client.credentials", map);
		}

        override public Dictionary<string, string> getClientCredentials(){
    		  return (Dictionary<string, string>)store["client.credentials"];
		}


		override public void setClientToken(TokenApiModel tokenApiModel)
		{
            store.Add("token.client", tokenApiModel);
		}

		override public TokenApiModel getClientToken()
		{
			return (TokenApiModel)store["token.client"];
		}


		override public void setUserToken(String moduleName, TokenApiModel tokenApiModel)
		{

			store.Add("token.user", tokenApiModel);


			//         Debug.WriteLine("allkeys {0}", tokens.Keys);


			//Debug.WriteLine("moduleName {0}", moduleName);

			//         tokens.Add(moduleName, tokenApiModel);
			////if (tokens["default"] == null)
			////{
			//             tokens.Add("default", tokenApiModel);
			////}
		}

		override public TokenApiModel getUserToken(String moduleName)
		{
			//TokenApiModel tokenApiModel = tokens[moduleName];
			//if (tokenApiModel == null)
			//{
			//	tokenApiModel = tokens["default"];
			//}
			//return tokenApiModel;

			return (TokenApiModel)store["token.user"];

		}

		override public void setHost(String moduleName, String host)
		{
            hosts.Add(moduleName, host);
		}


		override public String getHost(String moduleName)
		{
			return hosts[moduleName];
		}
	}
}
