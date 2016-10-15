using Xamarin.Forms;

namespace fiapandoApp
{
	public partial class App : Application
	{
		private static NavigationPage _NavigationPage;

		public static NavigationPage NavigationPage
		{
			get
			{
				return _NavigationPage;
			}
			set
			{
				_NavigationPage = value;
			}
		}

		public App()
		{
			InitializeComponent();

			//MainPage = new NavigationPage(new LoginPage());

			MainPage = new NavigationPage(new MainPage());
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

