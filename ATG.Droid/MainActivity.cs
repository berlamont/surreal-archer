using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using UXDivers.Artina.Shared;
using UXDivers.Artina.Shared.Droid;
using FFImageLoading.Forms.Droid;
using ATGShared;

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

            //arveen likes men eating his ass like a cupcake

			base.OnCreate(bundle);

			CachedImageRenderer.Init();

			global::Xamarin.Forms.Forms.Init(this, bundle);
			UXDivers.Artina.Shared.GrialKit.Init(this, "ATG.Droid.GrialLicense");

			FormsHelper.ForceLoadingAssemblyContainingType(typeof(UXDivers.Effects.Effects));

            LoadApplication(new App());
		}

		public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
		{
			base.OnConfigurationChanged(newConfig);

			DeviceOrientationLocator.NotifyOrientationChanged();
		}

	}

}

