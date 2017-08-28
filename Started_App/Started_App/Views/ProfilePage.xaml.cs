using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

using Started_App.Library.API.Models;
using Started_App.ViewModel;

using Newtonsoft.Json;

using Xamarin.Forms;

namespace Started_App.Views
{
    public partial class ProfilePage : ContentPage
    {

		HttpClient client;
	//	StreamContent streamContent;

        public ProfilePage(MemberApiModel member)
        {
            InitializeComponent();
            BindingContext = new ProfilePageViewModel(member);

			client = new HttpClient();

		}

		private async void takePic_click(object sender, EventArgs e)
		{
			var file = await CrossMedia.Current.PickPhotoAsync();
			if (file == null)
				return;
			//  await DisplayAlert("File Location", file.Path, "OK");

			var im = ImageSource.FromStream(() =>
			{
				var stream = file.GetStream();
				return stream;
			});

			image.Source = im;

			try
			{
				string RestUrl = "http://10.9.9.34:8080/img";
				var uri = new Uri(string.Format(RestUrl));


				MultipartFormDataContent muticontent = new MultipartFormDataContent();
				muticontent.Add(new StreamContent(file.GetStream()), "file", "file.jpg");
				var response = await client.PostAsync(uri, muticontent);

				var respcontent = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"   ERROR {0}", ex.Message);
			}
		}



	}
}
