using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ATG
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
		}

		

		async void OnCloseButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PopModalAsync();
		}

		public static bool IsPageInNavigationStack<TPage>(INavigation navigation) where TPage : Page {
			if (navigation.NavigationStack.Count > 1) {
				var last = navigation.NavigationStack [navigation.NavigationStack.Count - 2];

				if (last is TPage) {
					return true;
				}
			}
			return false;
		}
	}
}