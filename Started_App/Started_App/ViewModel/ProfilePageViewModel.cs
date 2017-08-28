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

using Started_App.Library.Modules.Token;
using Started_App.Library.Modules.Identity;
using Started_App.Library.Modules.IDS;
using Started_App.Library.API.Models;

using Xamarin.Forms;

namespace Started_App.ViewModel
{
    public class ProfilePageViewModel : BaseViewModel
    {

        private int userID;

		public ProfilePageViewModel(MemberApiModel member)
        {
            userID = member.id;

            this.getProfile(member);

			Debug.WriteLine("member {0}", member);
        }


        private string firstName;
		public string FirstName
		{
			get { return firstName; }
			set
			{
				firstName = value;
				OnPropertyChanged("FirstName");
			}
		}


		private string lastName;
		public string LastName
		{
			get { return lastName; }
			set
			{
				lastName = value;
				OnPropertyChanged("LastName");
			}
		}


		private string email;
        public string Email
		{
			get { return email; }
			set
			{
				email = value;
				OnPropertyChanged("Email");
			}
		}

		private string description;
		public string Description
		{
			get { return description; }
			set
			{
				description = value;
				OnPropertyChanged("Description");
			}
		}


        public async void getProfile(MemberApiModel member){

            Type identityApiClass = IDS.getModuleApi("identity");
			object instance = Activator.CreateInstance(identityApiClass);
			IdentityApi identityApi = instance as IdentityApi;

			//MemberApiModel memberDetails = identityApi.getProfile(member.id);
			MemberApiModel memberDetails = await identityApi.getProfile(member.id);

            Debug.WriteLine("memberDetails {0}", memberDetails.email);


            FirstName = memberDetails.firstName;
            LastName = memberDetails.lastName;
            Email = memberDetails.email;
            Description = memberDetails.description;

		}


		#region DelegateCommand
		Command TakePicButtonCommandCommand;
		/// <summary>
		/// Gets the save command.
		/// </summary>
		/// <value>The save command.</value>
		public Command TakePicButtonCommand
		{
			get
			{
				return TakePicButtonCommandCommand ?? (TakePicButtonCommandCommand = new Command(async () => await ExecuteOnTakePicClick()));
			}
		}
		#endregion


		#region Methods 

		private async Task ExecuteOnTakePicClick()
		{
			

		}

		#endregion




		#region DelegateCommand
		Command UpdateCommandCommand;
		/// <summary>
		/// Gets the save command.
		/// </summary>
		/// <value>The save command.</value>
		public Command UpdateCommand
		{
			get
			{
				return UpdateCommandCommand ?? (UpdateCommandCommand = new Command(async () => await ExecuteOnUpdate()));
			}
		}
		#endregion



		#region Methods 

		private async Task ExecuteOnUpdate()
		{

            Dictionary<string, string> profile = new Dictionary<string, string>();
            profile.Add("firstName",FirstName);
            profile.Add("lastName", LastName);
            profile.Add("email", Email);
            profile.Add("description", Description);


			Type identityApiClass = IDS.getModuleApi("identity");
			object instance = Activator.CreateInstance(identityApiClass);
			IdentityApi identityAPi = instance as IdentityApi;

            MemberApiModel member = await identityAPi.UpdateProfile(profile, userID);
			Debug.WriteLine("member {0}", member.email);

		}

		#endregion

	}
}
