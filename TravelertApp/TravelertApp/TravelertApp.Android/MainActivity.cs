using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Firebase;
using Android;

namespace TravelertApp.Droid
{
    [Activity(Label = "TravelertApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        //ID for our permissions request kuno.
        const int RequestLocationId = 0;

        //Permissions that we are requesting
        readonly string[] LocationPermissions =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };

        //Overriding the OnStart() method
        protected override void OnStart()
        {
            base.OnStart();

            if((int)Build.VERSION.SdkInt >= 23)
            {
                if(CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
                {
                    RequestPermissions(LocationPermissions, RequestLocationId);
                }
                else
                {
                    //Permissions already granted - display a message 
                }
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Before loading the app, we need to initialize the firebase database
            FirebaseApp.InitializeApp(Application.Context);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //Initializing the Maps
            Xamarin.FormsMaps.Init(this, savedInstanceState);

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            //
            if (requestCode == RequestLocationId)
            {
                if((grantResults.Length == 1) && (grantResults[0] == (int)Permission.Granted))
                {
                    //Permissions granted - display a message
                }
                else
                {
                    //Permissions denied - display a message
                }

            }
            else //whenever it is a different request code.
            {
                Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            }


            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}