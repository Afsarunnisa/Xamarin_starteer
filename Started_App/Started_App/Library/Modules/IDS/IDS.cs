using System;
using System.Collections.Generic;
using System.Diagnostics;

using Started_App.Library.API;

namespace Started_App.Library.Modules.IDS
{
    public class IDS
    {
        private static Dictionary<string, Type> registry = new Dictionary<string, Type>();


        public static Type getModuleApi(String moduleName)
		{
			return getModuleApi(moduleName, "app");
		}

        public static Type getModuleApi(string moduleName, string contextName)
        {

            if (!registry.ContainsKey(moduleName)){
                
            }else{


                Type apiClass = registry[moduleName];
                object instance = Activator.CreateInstance(apiClass);
                NetworkApi api = instance as NetworkApi;


				
				ApiContext apiContext = AbstractApiContext.get(contextName);
                api.setApiContext(apiContext);


                string host = api.getHost();

                if(host == ""){
                    host = "http://api.qa1.nbos.in/";
                }

                api.setHost(host);

                return registry[moduleName];
			}
            return null;
        }

        public static void register(String moduleName, Type clazz)
		{
            registry.Add(moduleName, clazz);
		}


		public IDS()
        {
        }
    }
}
