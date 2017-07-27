using System;
using System.Collections.Generic;
using System.Diagnostics;



using Started_App.Library.API.Models;

namespace Started_App.Library.API
{
    public abstract class AbstractApiContext : ApiContext
    {

		protected String name = "app";
		private static Dictionary<String, ApiContext> apiContexts = new Dictionary<String, ApiContext>();

		public abstract String getName();

		public abstract void setHost(String moduleName, String host);
		public abstract String getHost(String moduleName);


		public abstract void setClientCredentials(Dictionary<string, string> map);
		public abstract void setClientToken(TokenApiModel tokenApiModel);

		public abstract Dictionary<string, string> getClientCredentials();
		public abstract TokenApiModel getClientToken();

		public abstract void setUserToken(String moduleName, TokenApiModel tokenApiModel);
		public abstract TokenApiModel getUserToken(String moduleName);



		public AbstractApiContext()
        {
        }

		public AbstractApiContext(String name)
		{
			this.name = name;
		}

       


		public static void registerApiContext(ApiContext apiContext)
		{

            Debug.WriteLine("name {0} ", apiContext.getName());
            apiContexts.Add(apiContext.getName(), apiContext);
		}

		public static ApiContext get(String name)
		{
            if(apiContexts.ContainsKey(name)){

				ApiContext ctx = apiContexts[name];

				Debug.WriteLine("ctx {0}", ctx);

				if (ctx == null)
				{
					ctx = new InMemoryApiContext(name);
					registerApiContext(ctx);
				}

                Debug.WriteLine("ctx {0}", ctx);
				return ctx;
            }else{

                ApiContext ctx =  new InMemoryApiContext(name);
				registerApiContext(ctx);
				return ctx;

			}

                       


		}
	}
}