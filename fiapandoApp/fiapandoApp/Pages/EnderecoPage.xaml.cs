using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using Acr.UserDialogs;

using Xamarin.Forms;

namespace fiapandoApp
{
	public partial class EnderecoPage : ContentPage
	{
		public EnderecoPage()
		{
			InitializeComponent();
		}

		async void Cep_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
		{
			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri("http://viacep.com.br/");
				httpClient.DefaultRequestHeaders.Clear();

				var response = await httpClient.GetAsync("ws/" + CepEntry.Text + "/json");

				if (response.IsSuccessStatusCode)
				{
					var enderecoResult = JsonConvert.DeserializeObject<EnderecoResult>(await response.Content.ReadAsStringAsync());

					EnderecoEntry.Text = enderecoResult.Logradouro;
					BairroEntry.Text = enderecoResult.Bairro;
					CidadeEntry.Text = enderecoResult.Cidade;
					BairroEntry.Text = enderecoResult.Bairro;
					EstadoEntry.Text = enderecoResult.Estado;

					UserDialogs.Instance.ShowSuccess("CEP recuperado com sucesso!");
				}
				else
					UserDialogs.Instance.ShowError("Erro ao realizar consulta.");
			}
		}
	}
}

