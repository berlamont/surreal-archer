using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;


using Xamarin.Forms;
using ATGShared.Views.Login;

namespace ATGShared
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }



        async void OnCloseButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }

        async void OnRegisterClicked(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SignUpPage());

        }

        void OnLoginClicked(object sender, EventArgs args)
        {
            ArrayList Login = new ArrayList();
            String username = emailVar.Text;

            Login.Add(username);

            String password = passVar.Text;

            Login.Add(password);


            LoginBackend login = new LoginBackend();
            if (login.TryLogin(Login))
            {
                Navigation.PushAsync(new Page());

            }


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