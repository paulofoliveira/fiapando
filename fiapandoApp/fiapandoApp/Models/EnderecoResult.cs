using System;
using Newtonsoft.Json;

namespace fiapandoApp
{
	public class EnderecoResult
	{
		public EnderecoResult()
		{
		}

		[JsonProperty("logradouro")]
		public string Logradouro { get; set; }

		[JsonProperty("cep")]
		public string CEP { get; set; }

		[JsonProperty("bairro")]
		public string Bairro { get; set; }

		[JsonProperty("localidade")]
		public string Cidade { get; set; }

		[JsonProperty("complemento")]
		public string Complemento { get; set; }

		[JsonProperty("uf")]
		public string Estado { get; set; }
	}
}

