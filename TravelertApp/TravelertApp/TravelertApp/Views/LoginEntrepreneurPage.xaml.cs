using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelertApp.Models;
using TravelertApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelertApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginEntrepreneurPage : ContentPage
    {
        public LoginEntrepreneurPage()
        {
            InitializeComponent();
            Init();

            BindingContext = new EntrepreneursLoginViewModel(/*Navigation*/);
        }
        void Init()
        {
            //The login class is the extension of the ContentPage, we have variable called BackgroundColor
            BackgroundColor = Constants.BackgroundColor;

            Entry_Email.TextColor = Constants.MainTextColor;
            Entry_Email.PlaceholderColor = Constants.PlaceholderColor;
            Entry_Password.TextColor = Constants.MainTextColor;
            Entry_Password.PlaceholderColor = Constants.PlaceholderColor;


            Lbl_AppTitle.TextColor = Constants.MainTextColor;
            Btn_Signin.TextColor = Constants.MainTextColor;
            Btn_ForgotPassword.TextColor = Constants.MainTextColor;

            //Specifying the height of the logo
            // - if we don't do this, the logo will be set to the original size of the file
            // - to keep control of the design, we're going to specify the height in the constants class
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            ////Because we don't want to see the activity spinner when we are logging in, we set that to invisible
            //ActivitySpinner.IsVisible = false;

            //SAKA NA MUNA TONG SIGN IN
            ////Giving the Screen more usability
            ////When the username and the user presses the return key, the keyboard will be hidden. - this is not the behavior that we want
            //// - the focus should be set on the password entry field and when that is filled in and return key is pressed, the login function should be activated.
            //Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            //Entry_Password.Completed += (s, e) => SignInProcedure(s, e);

        }

        async private void Btn_ForgotPassword_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPasswordPage());
        }
    }
}