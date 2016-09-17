using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;

using Xamarin.Forms;

namespace fiapandoApp
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		async void LoginButton_Clicked(object sender, EventArgs e)
		{
			UserDialogs.Instance.ShowLoading("Logando como " + LoginEntry.Text + " ...");
			await Task.Delay(3000);
			UserDialogs.Instance.HideLoading();
			Navigation.InsertPageBefore(new TabbedMainPage(), this);
			await Navigation.PopAsync();
		}

		async void CadastrarButton_Clicked(object sender, System.EventArgs e)
		{
			Navigation.InsertPageBefore(new CadastrarPage(), this);
			await Navigation.PopAsync();
		}

		async void RecuperarButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new RecuperarSenhaPage());
		}
	}
}

