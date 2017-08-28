using System;
using System.Collections.Generic;
using Started_App.Model;

using Xamarin.Forms;

using Started_App.Library.API.Models;


namespace Started_App.Views
{
    public partial class MainPage : MasterDetailPage
    {
		public List<MenuItemModel> menuList { get; set; }

        MemberApiModel memberModel = new MemberApiModel();


        public MainPage(MemberApiModel member)
		{
			InitializeComponent();

            memberModel = member;

			menuList = new List<MenuItemModel>();

			var page1 = new MenuItemModel() { Title = "Home", Icon = "Home", TargetType = typeof(DashboardPage) };
            var page2 = new MenuItemModel() { Title = "Profile", Icon = "Profile", TargetType = typeof(ProfilePage) };
		
			menuList.Add(page1);
			menuList.Add(page2);
			//menuList.Add(page3);
			////menuList.Add(page4);
			//menuList.Add(page5);
			//menuList.Add(page6);
			////menuList.Add(page7);
			//menuList.Add(page8);

			menuListView.ItemsSource = menuList;

			Type page = typeof(DashboardPage);
			Detail = new NavigationPage((Page)Activator.CreateInstance(page, memberModel))
			{
				BarBackgroundColor = Color.FromHex("#06A2CB"),
				BarTextColor = Color.White,
			};


		}

		private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
		{

			if (e.SelectedItem == null) return; // don't do anything if we just de-selected the row

			var item = (MenuItemModel)e.SelectedItem;
			Type page = item.TargetType;


			if (item.Title == "All Products")
			{
				Page displayPage = (Page)Activator.CreateInstance(page, "0", "0");
				Detail = new NavigationPage(displayPage)
				{
					BarBackgroundColor = Color.FromHex("#06A2CB"),
					BarTextColor = Color.White,
				};
			}
			else
			{
				Detail = new NavigationPage((Page)Activator.CreateInstance(page, memberModel))
				{
					BarBackgroundColor = Color.FromHex("#06A2CB"),
					BarTextColor = Color.White,
				};
			}

			IsPresented = false;

			//((ListView)sender).SelectedItem = null;

			((ListView)sender).SelectedItem = null; // de-select the row

		}
    }
}
