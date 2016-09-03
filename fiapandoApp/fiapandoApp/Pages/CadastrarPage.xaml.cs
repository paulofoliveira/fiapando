using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;

using Xamarin.Forms;

namespace fiapandoApp
{
	public partial class CadastrarPage : ContentPage
	{
		public CadastrarPage()
		{
			InitializeComponent();
		}

		async void SairToolbarItem_Clicked(object sender, System.EventArgs e)
		{
			UserDialogs.Instance.ShowLoading("Saindo ...");
			await Task.Delay(1000);
			UserDialogs.Instance.HideLoading();
			App.Current.MainPage = new NavigationPage(new LoginPage());
		}
	}
}

