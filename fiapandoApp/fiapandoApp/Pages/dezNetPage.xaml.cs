using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fiapandoApp
{
	public partial class dezNetPage : ContentPage
	{
		public dezNetPage()
		{
			InitializeComponent();
		}

		async void Entrar_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new NavigationPage(new UserTabbedPage()));
		}

		void RecuperarSenha_Clicked(object sender, System.EventArgs e)
		{
			
		}
	}
}

