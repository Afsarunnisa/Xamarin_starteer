using System; using System.Windows.Input; using System.Collections.Generic; using System.Collections.ObjectModel; using System.ComponentModel; using System.Linq; using System.Runtime.CompilerServices; using System.Text; using System.Threading.Tasks; using System.Diagnostics;   using Started_App.Views;   using Started_App.Library.Modules.Token; using Started_App.Library.Modules.Identity; using Started_App.Library.Modules.IDS; using Started_App.Library.API.Models;   using Xamarin.Forms; 
namespace Started_App.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {

		private INavigation _navigation;

		public LoginViewModel(INavigation navitation)
        {
			_navigation = navitation;
            LoginUserObject = new LoginModel();   
			Type tokenApiClass = IDS.getModuleApi("token");
			object instance = Activator.CreateInstance(tokenApiClass);
			TokenApi tokenAPi = instance as TokenApi;

			tokenAPi.getClientToken(); 
		}            #region Properties         private LoginModel loginUserObject;         /// <summary>         /// Gets or sets the employee object.         /// </summary>         /// <value>The employee object.</value>         public LoginModel LoginUserObject         {             get              { return loginUserObject;              }             set {                 loginUserObject = value; OnPropertyChanged();             }         }        #endregion              #region DelegateCommand         Command LoginBtnCommandCommand;         /// <summary>         /// Gets the save command.         /// </summary>         /// <value>The save command.</value>        public Command LoginBtnCommand       {            get               {                 return LoginBtnCommandCommand ?? (LoginBtnCommandCommand = new Command(async () => await ExecuteOnLoginClick()));                }         }
        #endregion 


        #region Methods  
        private async Task ExecuteOnLoginClick()
        {
			var loginUser = LoginUserObject;

			Type identityApiClass = IDS.getModuleApi("identity");
			object instance = Activator.CreateInstance(identityApiClass);
            IdentityApi identityAPi = instance as IdentityApi;

            MemberApiModel member = await identityAPi.login(loginUser);
             if(member != null){                 await _navigation.PushAsync(new MainPage(member));
			} 		}

		#endregion 
            #region DelegateCommand         Command SignUpBtnCommandCommand;         /// <summary>         /// Gets the save command.         /// </summary>         /// <value>The save command.</value>        public Command SignUpBtnCommand       {            get               {                 return SignUpBtnCommandCommand ?? (SignUpBtnCommandCommand = new Command(async () => await ExecuteOnSignUpClick()));                }         }
		#endregion 

		#region Methods  
		private async Task ExecuteOnSignUpClick()
		{
            await _navigation.PushAsync(new SignUpPage());
		}

		#endregion 
	}
}
