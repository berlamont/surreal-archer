using ATGShared.Views.Login;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace ATGShared
{
	public partial class SignUpPage : ContentPage
	{
		private TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();

		public SignUpPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			tapGestureRecognizer.Tapped += OnLoginStackTapped;
			loginStack.GestureRecognizers.Add(tapGestureRecognizer);
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			tapGestureRecognizer.Tapped -= OnLoginStackTapped;
			loginStack.GestureRecognizers.Remove(tapGestureRecognizer);
		}

		public async void OnLoginStackTapped(object sender, EventArgs e)
		{
			if (LoginPage.IsPageInNavigationStack<LoginPage> (Navigation)) {
				await Navigation.PopAsync ();
				return;
			}
				
			var loginPage = new LoginPage();
			await Navigation.PushAsync(loginPage);
		}


        public void OnSignUpClicked(object sender, EventArgs e)
        {
            ArrayList signUp = new ArrayList();

            String phone = phoneVar.Text;
            signUp.Add(phone);

            String user = userSignUp.Text;
            signUp.Add(user);

            String pass = passwordEntry.Text;
            signUp.Add(pass);

            RegisterBackend backend = new RegisterBackend();

            if (backend.TryRegister(signUp) == true)
            {
                Navigation.PushAsync(new Page());
            }

        }
        





        async void OnLoginClicked(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new LoginPage());
        }

        async void OnCloseButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PopModalAsync();
		}
	}
}