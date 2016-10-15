using System;
using SQLite;

namespace fiapandoApp
{
	public interface ISQLiteService
	{
		SQLiteConnection GetConnection(string databaseName);
		long GetSize(string databaseName);
	}
}
