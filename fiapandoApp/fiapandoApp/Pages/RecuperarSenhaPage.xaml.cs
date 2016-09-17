using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Acr.UserDialogs;

namespace fiapandoApp
{
	public partial class RecuperarSenhaPage : ContentPage
	{
		public RecuperarSenhaPage()
		{
			InitializeComponent();
		}

		void Recuperar_Clicked(object sender, System.EventArgs e)
		{
			UserDialogs.Instance.ShowSuccess("Email enviado para " + RecuperarEntry.Text + "!");
		}

		async void Voltar_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync(true);
		}

	}
}

