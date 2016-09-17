using System;
using Newtonsoft.Json;

namespace fiapandoApp
{
	public class TempoResultModel
	{
		public TempoResultModel()
		{
		}

		[JsonProperty("weatherObservation")]
		public WeatherObservation WeatherObservation { get; set; }


	}

	public class WeatherObservation
	{
		[JsonProperty("temperature")]
		public string Temperature { get; set; }

		[JsonProperty("stationName")]
		public string StationName { get; set; }
	}
}

