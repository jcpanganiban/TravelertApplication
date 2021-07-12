using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TravelertApp.Models
{
    public class Constants
    {
        //The first variable will be:
        //This variable is used to indicate if you're developing or if you're using release code
        public static bool IsDev = true;

        #region Xamarin Tutorial Episode 3: Login Screen
        // In this tutorial, we will be looking at the design of the login screen
        // - This will include:
        // 1. Background Color 
        // 2. Padding
        // 3. Logo
        // 4. Margin around all the elements.
        // 5. We also want to show the user when the login is loading.
        //    - This is done by using activity spinner

        //Specifying the background color and a main text color to set all the text in the app
        // - We will do this by adding a constant to the constants class

        public static Color BackgroundColor = Color.FromRgb(25, 25, 112); //Ginawa ko ng midnight blue
        public static Color MainTextColor = Color.White;
        public static Color PlaceholderColor = Color.LightGray;

        //In android, you can set this by using styles.
        // - but the IOS and windows version work differently.
        // - By using this approach, all devices are supported

        //The upside of this is that you have one central place for all your colors
        // - if you want to change the look of your app, you only have to change it in your constants class.

        //Setting a constant value for the height of the LoginIcon
        public static int LoginIconHeight = 120; //for the phone

        //For tablets, we should use a greater number

        #endregion Xamarin Tutorial Episode 3: Login Screen

        public static string WebAPIkey = "AIzaSyCymQERg_PzlSw31GFFjnVJFkPtK4gXY48";

    }
}
