using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelertApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TravelertApp.Models;
using Newtonsoft.Json;
using Firebase.Database;
using TravelertApp.Services;

namespace TravelertApp.Views.ProfilePageUsers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsumerProfilePage : ContentPage
    {
        private string ConsumerUID;

        public ConsumerProfilePage(string consumerUID)
        {
            InitializeComponent();
            ConsumerUID = consumerUID;


            #region GestureRecognizers
            //var tapGestureRecognizerHomePage = new TapGestureRecognizer();
            //tapGestureRecognizerHomePage.Tapped += async (s, e) => {
            //    // handle the tap
            //    await Navigation.PushAsync(new GeneralPublicPage(ConsumerUID));
            //};
            //Lbl_GoToHomePage.GestureRecognizers.Add(tapGestureRecognizerHomePage);

            //var tapGestureRecognizerProfilePage = new TapGestureRecognizer();
            //tapGestureRecognizerProfilePage.Tapped += async (s, e) => {
            //    // handle the tap
            //    await Navigation.PushAsync(new ConsumerProfilePage(ConsumerUID));
            //};
            //Lbl_GoToProfilePage.GestureRecognizers.Add(tapGestureRecognizerProfilePage);

            //var tapGestureRecognizerSettingsPage = new TapGestureRecognizer();
            //tapGestureRecognizerSettingsPage.Tapped += async (s, e) => {
            //    // handle the tap
            //    await Navigation.PushAsync(new ConsumerSettingsPage(ConsumerUID));
            //};
            //Lbl_GoToSettingsPage.GestureRecognizers.Add(tapGestureRecognizerSettingsPage);
            #endregion GestureRecognizers

            //Getting the consumer info experiment??
            GetConsumerData();
        }

        private async void GetConsumerData()
        {
            try
            {
                var response = await ConsumerApiServices.ServiceClientInstance.GetConsumer(ConsumerUID);
                //Dito naten iseset ung value sa labels

                Lbl_FullName.Text = response.FullName;
                Lbl_Age.Text = response.Age.ToString();
                Lbl_Username.Text = response.Username;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"{ex.Message}\n{ex.StackTrace}", "Ok");
            }
        }

        private void Btn_Logout_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }

        //async private void GoToHome(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new GeneralPublicPage());
        //}
        //async private void GoToProfile(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new ConsumerProfilePage());
        //}
        //async private void GoToSettings(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new SettingsPage());
        //}


    }
}