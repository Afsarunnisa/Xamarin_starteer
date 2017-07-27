using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Started_App.ViewModel;

namespace Started_App.Views
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = new SignUpViewModel(this.Navigation);

		}
    }
}
