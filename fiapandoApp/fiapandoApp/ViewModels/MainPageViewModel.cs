using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace fiapandoApp
{
	public class MainPageViewModel : BaseViewModel
	{
		private readonly Database db;

		public string Nome { get; set; }
		public string SobreNome { get; set; }
		public string Idade { get; set; }
		public int SexoIndex { get; set; }

		public ObservableCollection<string> Registros { get; set; }

		public ICommand AdicionarCommand { get; set; }
		public ICommand ExcluirCommand { get; set; }
		public ICommand ExcluirTudoCommand { get; set; }
		public ICommand SexoCommand { get; set; }
		public ICommand IdadeFiltroCommand { get; set; }

		public MainPageViewModel()
		{
			AdicionarCommand = new Command(Adicionar);
			ExcluirCommand = new Command(Excluir);
			ExcluirTudoCommand = new Command(ExcluirTudo);
			SexoCommand = new Command(FiltroPorSexo);
			IdadeFiltroCommand = new Command(FiltroPorSexo);

			// Caso não exista, cria a base
			db = new Database("Pessoas");
			db.CreateTable<Pessoa>();

			Registros = new ObservableCollection<string>();
			MostrarTodosRegistros();
		}

		private void Adicionar()
		{
			int idade;
			if (int.TryParse(Idade, out idade))
			{
				var registro = new Pessoa(Nome, SobreNome, idade, SexoIndex == 0 ? Sexo.Feminino : Sexo.Masculino);

				db.SaveItem(registro);
				Registros.Add(registro.ToString());
				RaisePropertyChanged(nameof(Registros));
			}
		}

		private void Excluir(object obj)
		{
			var itemString = (string)obj;
			var colunas = itemString.Split(',').Select(p => p.Trim()).ToList();
			int id;

			if (int.TryParse(colunas[0], out id))
			{
				db.DeleteItem<Pessoa>(id);
				Registros.Clear();
				MostrarTodosRegistros();
			}
		}

		private void ExcluirTudo()
		{
			db.DeleteAll<Pessoa>();
			Registros.Clear();
		}

		private void FiltroPorIdade(object obj)
		{
			int idade;
			if (int.TryParse((string)obj, out idade))
			{
				var resultado = db.Query<Pessoa>("SELECT * FROM Pessoa WHERE Idade > ?", new object[] { idade });
				Registros.Clear();

				foreach (var pessoa in resultado)
					Registros.Add(pessoa.ToString());
			}
		}


		private void FiltroPorSexo(object obj)
		{
			var sexo = (string)obj == "Feminino" ? Sexo.Feminino : Sexo.Masculino;
			var resultado = db.Query<Pessoa>("SELECT * FROM Pessoa WHERE Sexo = ?", new object[] { sexo });

			Registros.Clear();

			foreach (var pessoa in resultado)
				Registros.Add(pessoa.ToString());
		}

		private void LimparTela()
		{
			Nome = SobreNome = Idade = string.Empty;
			SexoIndex = -1;

			RaisePropertyChanged(nameof(Nome));
			RaisePropertyChanged(nameof(SobreNome));
			RaisePropertyChanged(nameof(Idade));
			RaisePropertyChanged(nameof(SexoIndex));
		}

		private void MostrarTodosRegistros()
		{
			Registros.Clear();
			var pessoas = db.GetItems<Pessoa>();

			foreach (var pessoa in pessoas)
				Registros.Add(pessoa.ToString());
		}
	}
}
