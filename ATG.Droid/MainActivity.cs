using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using System.Threading.Tasks;

using UXDivers.Artina.Shared;
using UXDivers.Artina.Shared.Droid;

using FFImageLoading.Forms.Droid;
using Parse;

namespace ATG.Droid
{
	//https://developer.android.com/guide/topics/manifest/activity-element.html
	[Activity(
		Label = "ATG",
		Icon = "@drawable/icon",
		Theme = "@style/Theme.Splash",
	 	MainLauncher = true,
		LaunchMode = LaunchMode.SingleTask,
		ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize
		)
	]
	public class MainActivity : FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.Window.RequestFeature(WindowFeatures.ActionBar);
			base.SetTheme(Resource.Style.AppTheme);


			FormsAppCompatActivity.ToolbarResource = Resource.Layout.Toolbar;
			FormsAppCompatActivity.TabLayoutResource = Resource.Layout.Tabs;

			base.OnCreate(bundle);

			CachedImageRenderer.Init();

			global::Xamarin.Forms.Forms.Init(this, bundle);
			UXDivers.Artina.Shared.GrialKit.Init(this, "ATG.Droid.GrialLicense");

			FormsHelper.ForceLoadingAssemblyContainingType(typeof(UXDivers.Effects.Effects));

            /* PARSE-BACKEND INIT */

            ParseClient.Initialize(new ParseClient.Configuration
            {
                ApplicationId = "5W6K38S1TQRPNVJV64Y9",
                Server = "http://158.69.210.237:2017/backend/"
            });

            LoadApplication(new App());
		}

		public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
		{
			base.OnConfigurationChanged(newConfig);

			DeviceOrientationLocator.NotifyOrientationChanged();
		}

	}

}

