using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;


namespace fiapandoApp
{
	public partial class DadosPage : ContentPage
	{
		public DadosPage()
		{
			InitializeComponent();

			GeoLoc();
		}

		async void GeoLoc()
		{
			// http://api.geonames.org/findNearByWeatherJSON?lat=0&lng=0&username=deznetfiap


			var current = CrossGeolocator.Current;
			current.DesiredAccuracy = 50;

			var position = await current.GetPositionAsync(10000);

			double lat = position.Latitude;
			double lng = position.Longitude;

			var pst = new Position(lat, lng);

			var mapSpan = MapSpan.FromCenterAndRadius(pst, Distance.FromMiles(1));

			var pin = new Pin()
			{
				Type = PinType.Place,
				Position = pst,
				Label = "Minha localizacao",
				Address = "Fiap"
			};

			MapaPadraoMap.Pins.Add(pin);
			MapaPadraoMap.MoveToRegion(mapSpan);

			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri("http://api.geonames.org/");

				var response = await httpClient.GetAsync($"findNearByWeatherJSON?lat={ lat.ToString() }&lng={ lng.ToString() }&username=deznetfiap");

				if (response.IsSuccessStatusCode)
				{
					var tempoResult = JsonConvert.DeserializeObject<TempoResultModel>(await response.Content.ReadAsStringAsync());

					LocalizacaoLabel.Text = tempoResult.WeatherObservation.StationName;
					TemperaturaLabel.Text = tempoResult.WeatherObservation.Temperature;

				}
			}

		}
	}
}

