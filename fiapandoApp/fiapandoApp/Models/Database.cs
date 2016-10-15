using System;
using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace fiapandoApp
{
	public class Database
	{
		private static object locker = new object();
		private readonly SQLiteConnection connection;
		private readonly string databaseName;

		public Database(string databaseName)
		{
			this.databaseName = databaseName;
			connection = SQLite.GetConnection(this.databaseName);
		}

		private ISQLiteService SQLite
		{
			get
			{
				return DependencyService.Get<ISQLiteService>();
			}
		}

		public void CreateTable<T>()
		{
			lock(locker)
			{
				connection.CreateTable<T>();
			}
		}

		public long GetSize()
		{
			return SQLite.GetSize(databaseName);
		}

		public int SaveItem<T>(T item)
		{
			lock(locker)
			{
				var id = ((BaseItem)(object)item).ID;
				if (id == 0)
					return connection.Insert(item);

				connection.Update(item);
				return id;
			}
		}

		public void ExecuteQuery(string query, object[] args)
		{
			lock (locker)
			{
				connection.Execute(query, args);
			}
		}

		public List<T> Query<T>(string query, object[] args) where T : new()
		{
			lock (locker)
			{
				return connection.Query<T>(query, args);
			}
		}

		public IEnumerable<T> GetItems<T>() where T : new()
		{
			lock (locker)
			{
				return (from p in connection.Table<T>() select p).ToList();
			}
		}

		public int DeleteItem<T>(int id)
		{
			lock (locker)
			{
				return connection.Delete<T>(id);
			}
		}

		public int DeleteAll<T>()
		{
			lock (locker)
			{
				return connection.DeleteAll<T>();
			}
		}
	}
}
