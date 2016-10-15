using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fiapandoApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			BindingContext = new MainPageViewModel();
		}
	}
}
