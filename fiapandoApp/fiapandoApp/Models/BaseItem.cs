using System;
using SQLite;

namespace fiapandoApp
{
	public class BaseItem
	{
		public BaseItem()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
	}
}
