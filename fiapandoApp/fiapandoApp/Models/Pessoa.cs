using System;
namespace fiapandoApp
{
	public enum Sexo
	{
		Feminino,
		Masculino
	}

	public class Pessoa : BaseItem
	{
		public Pessoa()
		{
		}

		public Pessoa(string nome, string sobreNome, int idade, Sexo sexo)
		{
			Nome = nome;
			SobreNome = sobreNome;
			Idade = idade;
			Sexo = sexo;
		}

		public string Nome { get; set; }
		public string SobreNome { get; set; }
		public int Idade { get; set; }
		public Sexo Sexo { get; set; }

		public override string ToString()
		{
			return $"{ ID }, { Nome }, { SobreNome }, { Idade }, { Sexo.ToString() }";
		}

	}
}
