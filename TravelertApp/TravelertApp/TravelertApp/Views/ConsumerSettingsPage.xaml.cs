using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelertApp.Views.ProfilePageUsers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelertApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsumerSettingsPage : ContentPage
    {
        private string ConsumerUID;

        public ConsumerSettingsPage(string consumerUID)
        {
            InitializeComponent();
            SetTheme.Items.Add("Default");
            SetTheme.Items.Add("Light Theme");
            SetTheme.Items.Add("Dark Theme");

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

        }
        private void SetTheme_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //private void OpenSwipe(object sender, EventArgs e)
        //{
        //    //anytime we want to open the swipe view, we're just going to call the MainSwipeView and take the open method
        //    // - and within that, we indicate the item that we want to open
        //    MainSwipeView.Open(OpenSwipeItem.LeftItems);
        //}
        //private void CloseSwipe(object sender, EventArgs e)
        //{
        //    //when we want to close the swipe view, we call the close method
        //    MainSwipeView.Close();
        //}
        //async private void GoToHome(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new EntrepreneurPage());
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