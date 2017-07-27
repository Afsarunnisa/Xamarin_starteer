using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;


using Newtonsoft.Json;

using Started_App.Library.API;
using Started_App.Library.API.Models;


namespace Started_App.Library.Modules.Identity
{
    public class IdentityApi : NetworkApi
    {
        public IdentityApi()
        {
            setModuleName("identity");
            setRemoteApiClass(typeof(IdentityRemoteApi));
        }

        public async Task<MemberApiModel> login(LoginModel login)
        {
            IdentityRemoteApi remoteAPI = new IdentityRemoteApi();
            IdsXamarinApiContext apiContext = AbstractApiContext.get("app") as IdsXamarinApiContext;

            Dictionary<string, string> clientCredentials = apiContext.getClientCredentials();

            login.clientID = clientCredentials["client_id"];

            var loginValue = await remoteAPI.login(login);

			Debug.WriteLine("tokenValue {0}", loginValue);

			NewMemberApiModel member = JsonConvert.DeserializeObject<NewMemberApiModel>(loginValue);

            apiContext.setUserToken("identity", member.token);

            Debug.WriteLine("firstName {0}", member.member.firstName);
			
            Debug.WriteLine("usrname  {0}", member.member.email);


            return member.member;
        }


        public async Task<MemberApiModel> signUp(SignUpModel signUp)
		{
			IdentityRemoteApi remoteAPI = new IdentityRemoteApi();
			IdsXamarinApiContext apiContext = AbstractApiContext.get("app") as IdsXamarinApiContext;

			Dictionary<string, string> clientCredentials = apiContext.getClientCredentials();

			signUp.clientID = clientCredentials["client_id"];

            var signupValue = await remoteAPI.signUp(signUp);

			Debug.WriteLine("signupValue {0}", signupValue);

			NewMemberApiModel memberModel = JsonConvert.DeserializeObject<NewMemberApiModel>(signupValue);
			apiContext.setUserToken("identity", memberModel.token);

			Debug.WriteLine("memberModel {0}", memberModel);
            Debug.WriteLine("memberModel {0}", memberModel.member);
            Debug.WriteLine("memberModel {0}", memberModel.member.email);

            return memberModel.member;

		}
    }
}