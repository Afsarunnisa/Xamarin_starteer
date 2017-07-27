using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


using Started_App.Views;

using Started_App.Library.Modules.Token;
using Started_App.Library.Modules.Identity;
using Started_App.Library.Modules.IDS;
using Started_App.Library.API.Models;


using Xamarin.Forms;

namespace Started_App.ViewModel
{
    public class SignUpViewModel : BaseViewModel
    {

		private INavigation _navigation;


		public SignUpViewModel(INavigation navitation)
        {
			_navigation = navitation;
            SignUpUserObject = new SignUpModel();

		}

		#region Properties
        private SignUpModel signUpUserObject;
		/// <summary>
		/// Gets or sets the employee object.
		/// </summary>
		/// <value>The employee object.</value>
		public SignUpModel SignUpUserObject
		{
			get
			{
				return signUpUserObject;
			}
			set
			{
				signUpUserObject = value; OnPropertyChanged();
			}
		}
		#endregion


		#region DelegateCommand
		Command SignUpBtnCommandCommand;
		/// <summary>
		/// Gets the save command.
		/// </summary>
		/// <value>The save command.</value>
		public Command SignUpBtnCommand
		{
			get
			{
				return SignUpBtnCommandCommand ?? (SignUpBtnCommandCommand = new Command(async () => await ExecuteOnSignUpClick()));
			}
		}
        #endregion

        #region Methods 

        private async Task ExecuteOnSignUpClick()
        {
			var signUpUser = SignUpUserObject;

            Debug.WriteLine("signUpUser firstname {0}", signUpUser.firstName);

			Debug.WriteLine("signUpUser username {0}", signUpUser.username);

			Debug.WriteLine("signUpUser password {0}", signUpUser.password);

			Type identityApiClass = IDS.getModuleApi("identity");
			object instance = Activator.CreateInstance(identityApiClass);
			IdentityApi identityAPi = instance as IdentityApi;

          //  identityAPi.signUp(signUpUser);

			MemberApiModel member = await identityAPi.signUp(signUpUser);


			Debug.WriteLine("member name {0}", member.email);
			Debug.WriteLine("member name {0}", member.firstName);

		}

		#endregion


	}
}
