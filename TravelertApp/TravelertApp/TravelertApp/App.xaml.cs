using System;
using TravelertApp.ViewModels;
using TravelertApp.Views;
using TravelertApp.Views.ProfilePageUsers;
using TravelertApp.Views.RegisterUsers;
using TravelertApp.Views.TabbedPageUsers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelertApp
{
    public partial class App : Application
    {
        private string ConsumerUID;

        public App()
        {
            InitializeComponent();
            //auth = DependencyService.Get<IAuth>();

            try
            {

                //ung normal code nung wala ung firesharp
                if (ConsumersLoginViewModel.IsLoggedIn || EntrepreneursLoginViewModel.IsLoggedIn) //if the user is signed in
                {
                    //if (!ConsumersLoginViewModel.IsLoggedIn) //if the user is a consumer
                    //{
                    //    MainPage = new NavigationPage(new GeneralPublicPage());
                    //}
                    //else if (!EntrepreneursLoginViewModel.IsLoggedIn) //else if the user is an entrepreneur
                    //{
                    //    MainPage = new NavigationPage(new EntrepreneurPage());
                    //}
                    //else
                    //{
                    //    return;
                    //}
                }
                else
                {
                    MainPage = new NavigationPage(new LoginPage()); //dapat login page to, pag may itetest na pages palitan lang
                }
            }
            catch (Exception e)
            {
                Current.MainPage.DisplayAlert("Alert", "There was a problem in the connection", "Ok");
            }



            //MainPage = new NavigationPage(new RegisterGeneralPublicPage());
            //changing this to new NavigationPage and pass the home page (LoginPage) as the parameter
            // - if we don't do this modification, then our application will get an exception


            //Pag experimental daw ung projects eto lalagay?? Tas tatanggalin pag iimplement na?
            Device.SetFlags(new[] { "SwipeView_Experimental" });
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
