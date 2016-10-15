using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace fiapandoApp
{
	public class BaseViewModel
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public BaseViewModel()
		{
		}

		protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			var handler = PropertyChanged;

			if (handler == null) return;
			handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
