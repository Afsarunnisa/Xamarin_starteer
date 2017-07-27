using Xamarin.Forms;

using Started_App.Library.Modules.IDS;
using Started_App.Library.Modules.Token;
using Started_App.Library.Modules.Identity;
using Started_App.Views;

using Started_App.Library.API;



namespace Started_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            IdsXamarinApiContext app_context = new IdsXamarinApiContext();
            _ = new IdnSDK(app_context);

		    _ = new TokenIdsRegistry();
            _ = new IdentityIdsRegistry();


			//  let app_context = IdsIosApiContext.init(name: "app")
			//  _ = IdnSDK.init(apiContext: app_context)

			// IDS.register("token", typeof(TokenApi));

			MainPage = new NavigationPage(new LoginPage());


        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
