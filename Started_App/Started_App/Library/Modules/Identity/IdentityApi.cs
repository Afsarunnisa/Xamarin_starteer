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

			NewMemberApiModel member = JsonConvert.DeserializeObject<NewMemberApiModel>(loginValue);
            Debug.WriteLine("login token {0}", member.token.access_token);

            apiContext.setUserToken("identity", member.token);

			return member.member;
        }


        public async Task<MemberApiModel> signUp(SignUpModel signUp)
		{
			IdentityRemoteApi remoteAPI = new IdentityRemoteApi();
			IdsXamarinApiContext apiContext = AbstractApiContext.get("app") as IdsXamarinApiContext;

			Dictionary<string, string> clientCredentials = apiContext.getClientCredentials();

			signUp.clientID = clientCredentials["client_id"];

            var signupValue = await remoteAPI.signUp(signUp);

			NewMemberApiModel memberModel = JsonConvert.DeserializeObject<NewMemberApiModel>(signupValue);
			apiContext.setUserToken("identity", memberModel.token);

			Debug.WriteLine("signup token {0}", memberModel.token);


			return memberModel.member;

		}

        public async Task<MemberApiModel> getProfile(int userId){

			IdentityRemoteApi remoteAPI = new IdentityRemoteApi();
			IdsXamarinApiContext apiContext = AbstractApiContext.get("app") as IdsXamarinApiContext;

            var profileValue = await remoteAPI.GetProfile(userId);

            MemberApiModel memberModel = JsonConvert.DeserializeObject<MemberApiModel>(profileValue);

            return memberModel;
		}


        public async Task<MemberApiModel> UpdateProfile(Dictionary<string, string> userDetails, int userId)
        {
			IdentityRemoteApi remoteAPI = new IdentityRemoteApi();
			IdsXamarinApiContext apiContext = AbstractApiContext.get("app") as IdsXamarinApiContext;

            var profileValue = await remoteAPI.UpdateProfile(userDetails, userId);

            Debug.WriteLine("profileValue {0}", profileValue);

			MemberApiModel memberModel = JsonConvert.DeserializeObject<MemberApiModel>(profileValue);

			return memberModel;
        }


	}
}