using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelertApp.Models;
using TravelertApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FBFirebaseConfig = Firebase.Auth.FirebaseConfig;

namespace TravelertApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        //IAuth auth;
        

        public LoginPage()
        {
            //this initializes all the components you specify in your XAML file 
            InitializeComponent();
            //this.BindingContext = new ConsumersLoginViewModel();

            //Making and using the Init Function
            Init();

            //auth = DependencyService.Get<IAuth>();
        }
        //Xamarin Tutorial Episode 3 - Login Screen Design
        //Setting the Background and MainText color
        void Init()
        {
            //The login class is the extension of the ContentPage, we have variable called BackgroundColor
            BackgroundColor = Constants.BackgroundColor;

            //Entry text colors
            //Entry_Username.TextColor = Constants.MainTextColor;
            //Entry_Username.PlaceholderColor = Constants.PlaceholderColor;
            //Entry_Password.TextColor = Constants.MainTextColor;
            //Entry_Password.PlaceholderColor = Constants.PlaceholderColor;


            Lbl_AppTitle.TextColor = Constants.MainTextColor;
            Btn_SigninAsConsumer.TextColor = Constants.MainTextColor;
            Btn_SigninAsEntrepreneur.TextColor = Constants.MainTextColor;

            Lbl_NotRegisteredYet.TextColor = Constants.MainTextColor;
            Btn_Register.TextColor = Constants.MainTextColor;

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
        #region SignIn Event
        //async void Btn_Signin_Clicked(object sender, EventArgs e)
        //{
        //    var authProvider = new FirebaseAuthProvider(new FBFirebaseConfig(Constants.WebAPIkey));
        //    try
        //    {
        //        #region Ung dating code before ayusin ung userRole
        //        var auth = await authProvider.SignInWithEmailAndPasswordAsync(Entry_Username.Text, Entry_Password.Text);
        //        var content = await auth.GetFreshAuthAsync();
        //        var serializedContent = JsonConvert.SerializeObject(content);
        //        Preferences.Set("MyFirebaseRefreshToken", serializedContent);

        //        //Para ma-access ung Entry_Username which ung email dito sa xaml file na to.
        //        //Application.Current.Properties["Name"] = Entry_Username.Text; //creating a session or space wherein we store a temporary value.

        //        //if ()
        //        //{
        //        //    await Navigation.PushAsync(new GeneralPublicPage());
        //        //}
        //        //else if ()
        //        //{
        //        //    await Navigation.PushAsync(new EntrepreneurPage());
        //        //}
        //        //else
        //        //{
        //        //    await DisplayAlert("Authentication Failed", "Incorrect email o password", "Ok");
        //        //}

        //        #endregion Ung dating code before ayusin ung userRole

        //        ////This is the saved firebaseauthentication that was saved during the time of login
        //        //var savedfirebaseauth = JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));

        //        ////Here we are Refreshing the token
        //        //var RefreshedContent = await authProvider.RefreshAuthAsync(savedfirebaseauth);
        //        //Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));

        //        //Now lets grab user information


        //        ////may babaguhin dito, dito na isasalpak ung pagretrieve ng data dun sa isang video
        //        //if (client.Get("Consumers/" + savedfirebaseauth.User.LocalId) == null && client.Get("Entrepreneurs/" + savedfirebaseauth.User.LocalId) == null) //kapag walang consumers at entrepreneurs sa datbase
        //        //{
        //        //    await Application.Current.MainPage.DisplayAlert("Error", "There are no users that are registered", "Ok");
        //        //}

        //        ////icomment muna to kasi wala pa naman nung entrepreneurs
        //        ////else if (client.Get("Consumers/" + savedfirebaseauth.User.LocalId) == null && client.Get("Entrepreneurs/" + savedfirebaseauth.User.LocalId) != null) //Kapag walang consumer sa database at merong entrepreneurs na kinukuha naten
        //        ////{
        //        ////    //result = client.Get("Entrepreneurs/" + savedfirebaseauth.User.LocalId);
        //        ////    //Consumer con = result.ResultAs<Entrepreneur>(); //IEEDIT PA PAG MERON NANG ENTREPRENEUR SHIT
        //        ////    await Navigation.PushAsync(new EntrepreneurPage());
        //        ////}

        //        //else if (client.Get("Entrepreneurs/" + savedfirebaseauth.User.LocalId) == null && client.Get("Consumers/" + savedfirebaseauth.User.LocalId) != null) //Kapag walang entrpreneur sa database at merong consumers na kinukuha naten
        //        //{
        //        //    //result = client.Get("Consumers/" + savedfirebaseauth.User.LocalId);
        //        //    //Consumer con = result.ResultAs<Consumer>();

        //        //    await Navigation.PushAsync(new GeneralPublicPage());
        //        //}
        //        //else //kapag merong consumers at entrepreneurs sa datbase na kinukuha naten
        //        //{
        //        //    //string pathConsumer = "Consumers/";
        //        //    //string pathEntrepreneur = "Entrepreneurs/";
        //        //    ////Dito naten aalamin kung ano ung user, kung Enrepreneur ba sya or Consumer
        //        //    //if () //Kung consumer
        //        //    //{
        //        //    //    result = client.Get("Consumers/" + savedfirebaseauth.User.LocalId);
        //        //    //    Consumer con = result.ResultAs<Consumer>();
        //        //    //}
        //        //    //else if () //kung entrepreneur
        //        //    //{
        //        //    //    //mali yan eh HAHAH d ko alam pano
        //        //    //}
        //        //    //else
        //        //    //{
        //        //    //    await DisplayAlert("Authentication Failed", "Incorrect email o password", "Ok");
        //        //    //}

        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Authentication Error", $"Something went wrong, please try again. {ex.Message}", "Ok");
        //    }

        //    //catch (Exception ex)
        //    //{
        //    //    await DisplayAlert("Authentication Failed", ex.Message, "Ok");
        //    //}
        //    //string token = await auth.LoginWithEmailAndPassword(Entry_Username.Text, Entry_Password.Text);
        //    ////await DisplayAlert("Authentication Failed", token, "Ok");//
        //    //if (token != string.Empty)
        //    //{
        //    //    //Redirect the user to a new sign in page
        //    //    Application.Current.MainPage = new GeneralPublicPage();
        //    //}
        //    //else
        //    //{
        //    //    await DisplayAlert("Authentication Failed", "Incorrect email o password", "Ok");
        //    //}
        //}
        #endregion SignIn Event


        //Navigation to the Register Page 
        async private void Btn_Register_Clicked(object sender, EventArgs e)
        {
            //LALAGYAN PA NG SIGNOUT
            //var signOut = auth.SignOut();
            //if (signOut)
            //{
            //    Application.Current.MainPage = new RegisterPage();
            //}
            await Navigation.PushAsync(new RegisterPage());
        }

        //Trying navigation to the Forgot Password Page
        async private void Btn_ForgotPassword_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPasswordPage());
        }

        async private void Btn_SigninAsConsumer_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginConsumerPage());
        }

        async private void Btn_SigninAsEntrepreneur_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginEntrepreneurPage());
        }

        //SAKA NA MUNA TONG SIGN IN 
        //void SignInProcedure(object sender, EventArgs e) //
        //{
        //    //Instantiating the User class, with Using TravelertApp.Models directive
        //    User user = new User(Entry_Username.Text, Entry_Password.Text);
        //    //We can extract the entry fields by using the .Text 

        //    //Finishing the signing procedure
        //    if (user.CheckInformation()) //If the given username and text is not an empty string
        //    {
        //        //We will display a message
        //        DisplayAlert("Login", "Login Success", "Ok");
        //    }
        //    else
        //    {
        //        //We will display an error
        //        DisplayAlert("Login", "Login Failed, empty username or password", "Okay");
        //        //By using await function on this Display Alert, we need to make the sign in procedure async
        //        // - otheriwise, the function wont compile
        //    }

        //}
    }
    
}