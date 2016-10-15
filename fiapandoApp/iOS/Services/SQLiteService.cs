using System;
using SQLite;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(fiapandoApp.iOS.SQLiteService))]

namespace fiapandoApp.iOS
{
	public class SQLiteService : ISQLiteService
	{
		public SQLiteService()
		{
		}

		private string GetPath(string databaseName)
		{
			if (string.IsNullOrWhiteSpace(databaseName))
				throw new Exception("Database inválido");

			var sqliteFileName = $"{ databaseName }.db3";
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var libraryPath = Path.Combine(documentsPath, "..", "Library");
			var path = Path.Combine(libraryPath, sqliteFileName);

			return path;
		}

		public SQLiteConnection GetConnection(string databaseName)
		{
			return new SQLiteConnection(GetPath(databaseName));
		}

		public long GetSize(string databaseName)
		{
			var fileInfo = new FileInfo(GetPath(databaseName));
			if (fileInfo == null) return 0;

			return fileInfo.Length;
		}
	}
}
