using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using UXDivers.Artina.Shared;
using Xamarin.Forms.Xaml;

namespace ATGShared
{
	//[XamlCompilation (XamlCompilationOptions.Skip)]
	public partial class App : Application
	{
		public static MasterDetailPage MasterDetailPage;

		public App()
		{
			InitializeComponent();

            MainPage = new NavigationPage(GetMainPage());

			MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);
		}

		public static Page GetMainPage()
        {
            return new LoginPage();
        }
	}
}
