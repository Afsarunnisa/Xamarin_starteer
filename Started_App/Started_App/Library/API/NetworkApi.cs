using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks; 

using Newtonsoft.Json;

namespace Started_App.Library.API
{
    public class NetworkApi
    {

        protected String moduleName;
        protected String host;
        protected ApiContext apiContext;


        private Type remoteApiClass;
        private Object remoteApi;


        public NetworkApi()
        {
        }

        public NetworkApi(String host, Type remoteApiClass)
        {
            this.host = host;
            this.remoteApiClass = remoteApiClass;
        }

		public void setApiContext(ApiContext apiContext)
		{
			this.apiContext = apiContext;
		}



		public void setHost(String host)
        {
            this.host = host;
        }

        public String getHost()
        {
            return host;
        }

        public String getModuleName()
        {
            return moduleName;
        }

        public void setModuleName(String moduleName)
        {
            this.moduleName = moduleName;
        }

        public void setRemoteApiClass(Type remoteApiClass)
        {
            this.remoteApiClass = remoteApiClass;
        }

        public Type getRemoteApiClass()
        {
            return this.remoteApiClass;
        }


        public async void getRequest(string requestUrl, Dictionary<string, string> paramsDict, Dictionary<string, string> headers, string token)
        {
			var myHttpClient = new HttpClient();
            var content = this.GetStringContent(paramsDict);

			myHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			var response = await myHttpClient.GetAsync(requestUrl);

            Debug.WriteLine("response {0}", response);

		}

        public async void getRequestWithEncode(string requestUrl, Dictionary<string, string> paramsDict, Dictionary<string, string> headers, string token)
        {


			var myHttpClient = new HttpClient();
            var content = this.GetFromContent(paramsDict);

			myHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await myHttpClient.GetAsync(requestUrl);

			Debug.WriteLine("response {0}", response);


		}

        public async Task<HttpResponseMessage> postRequest(string requestUrl, object jsonObject, Dictionary<string, string> headers, string token)
        {
			var myHttpClient = new HttpClient();
		//	var content = this.GetStringContent(paramsDict);


            try{

				Debug.WriteLine("token {0}", token);

				if (token != "")
				{
					myHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
				}


				var json = JsonConvert.SerializeObject(jsonObject);
				var content = new StringContent(json, Encoding.UTF8, "application/json");

				Debug.WriteLine("json {0}", json);

				Debug.WriteLine("content {0}", content);


				Debug.WriteLine("requestUrl {0}", requestUrl);


				HttpResponseMessage response = await myHttpClient.PostAsync(requestUrl, content);

				Debug.WriteLine("response {0}", response);

				return response;
			}
			catch (Exception ex)

			{
				Debug.WriteLine(@"   ERROR {0}", ex.Message);
                return null;
			}
		

		}


        public async Task<HttpResponseMessage> postRequestWithEncode(string requestUrl, Dictionary<string, string> paramsDict, Dictionary<string, string> headers, string token)
        {

			var myHttpClient = new HttpClient();
            var content = this.GetFromContent(paramsDict);

            if (token != "")
			{
				myHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			}

			HttpResponseMessage response = await myHttpClient.PostAsync(requestUrl, content);

			Debug.WriteLine("response {0}", response);

            return response;
        }

        public async void putRequestWithEncode(string requestUrl, Dictionary<string, string> paramsDict, Dictionary<string, string> headers, string token)
        {

			var myHttpClient = new HttpClient();
            var content = this.GetFromContent(paramsDict);

			myHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await myHttpClient.PutAsync(requestUrl, content);

			Debug.WriteLine("response {0}", response);


        }

        public async void delete(string requestUrl, Dictionary<string, string> paramsDict, Dictionary<string, string> headers, string token)
        {

			var myHttpClient = new HttpClient();
            var content = this.GetStringContent(paramsDict);

			myHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await myHttpClient.DeleteAsync(requestUrl);

            Debug.WriteLine("response {0}", response);


        }

        public StringContent GetStringContent(Dictionary<string, string> paramsDict)
        {
            Debug.WriteLine("response {0}", paramsDict.Keys);

            foreach (var key in paramsDict.Keys){
                Debug.WriteLine("key {0} value {1}", key, paramsDict[key]);
            }

            return new StringContent(JsonConvert.SerializeObject(paramsDict), Encoding.UTF8, "application/json");
        }


        public FormUrlEncodedContent GetFromContent(Dictionary<string, string> paramsDict){
            return new FormUrlEncodedContent(paramsDict);
		}

    }
}