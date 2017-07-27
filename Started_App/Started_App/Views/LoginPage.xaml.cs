using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

using Started_App.Library.Modules.Token;
using Started_App.Library.Modules.IDS;

using Started_App.ViewModel;


namespace Started_App.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = new LoginViewModel(this.Navigation);






		}
    }
}
