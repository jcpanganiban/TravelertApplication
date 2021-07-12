using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelertApp.Models;
using TravelertApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FBFirebaseConfig = Firebase.Auth.FirebaseConfig;

namespace TravelertApp.Views.RegisterUsers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterGeneralPublicPage : ContentPage
    {
        public RegisterGeneralPublicPage()
        {
            InitializeComponent();

            BindingContext = new ConsumersSignUpVM(); //RegisterViewModel();
        }

        #region Clicked Event (na tinanggal)
        //async private void Btn_RegisterAsConsumer_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {


        //        //
        //        //Entry_Username.Text = auth.User.LocalId;
        //        ////
        //        //firebaseObject = (FirebaseObject<Consumer>)
        //        //auth.User.LocalId = firebaseObject.Key;

        //        //client = new FireSharp.FirebaseClient(fcon);
        //        //Consumer con = new Consumer()
        //        //{
        //        //    FullName = Entry_FullName.Text,
        //        //    Age = int.Parse(Entry_Age.Text), //convert string to int
        //        //    IsConsumer = true
        //        //};
        //        //var setter = client.Set("Consumers/" + auth.User.LocalId, con);

        //        //string gettoken = auth.FirebaseToken;
        //        //await Application.Current.MainPage.DisplayAlert("Success", gettoken, "Ok");

        //        //try lang: command para mapunta ung data sa user.
        //        //c = new ConsumersViewModel();
                
        //        await Navigation.PushAsync(new LoginPage());
                
        //    }
        //    catch (Exception ex)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Error", $"Something went wrong, please try again. {ex.Message}", "Ok");
        //    }



        //    //var user = auth.SignUpWithEmailAndPassword(Entry_Email_Address.Text, Entry_Password.Text);

        //    //So, if the user has been created, we need to divert the user to the main page for login
        //    //if(user != null)
        //    //{
        //    //    await DisplayAlert("Success", "You have successfully created an account!", "Ok");

        //    //    //we need to call the sign out method
        //    //    var signOut = auth.SignOut();

        //    //    if (signOut) //if sign out we need to redirect the user to the main page
        //    //    {
        //    //        Application.Current.MainPage = new LoginPage();
        //    //    }
        //    //    else
        //    //    {
        //    //        await DisplayAlert("Error", "Something went wrong, please try again.", "Ok");
        //    //    }
        //    //}

        //    ////This code will send the username and password to the DB
        //    //FirebaseClient firebaseClient = new FirebaseClient("https://travelertappdb-default-rtdb.firebaseio.com/");
        //    //if (Entry_Password.Text == Entry_ConfirmPassword.Text)
        //    //{
        //    //    await firebaseClient
        //    //    .Child("Consumer")
        //    //    .PostAsync(new Consumer()
        //    //    {
        //    //        UserName = Entry_Username.Text,
        //    //        Password = Entry_Password.Text,
        //    //    });
        //    //}
        //    //await Navigation.PushAsync(new GeneralPublicPage());
        //}
        #endregion Clicked Event (na tinanggal)
    }
}