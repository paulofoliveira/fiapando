using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fiapandoApp
{
	public partial class RecuperarSenha2Page : ContentPage
	{
		public RecuperarSenha2Page()
		{
			InitializeComponent();
		}

		void Enviar_Clicked(object sender, System.EventArgs e)
		{
			DisplayAlert("Recuperar", "Senha enviada para " + RecuperarEntry.Text, "OK");
		}

		async void Cancelar_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
	}
}

