using System;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TravelertApp.Views;
using Xamarin.Forms;
using TravelertApp.Services;
using TravelertApp.Views.TabbedPageUsers;

namespace TravelertApp.ViewModels
{
    public class ConsumersLoginViewModel : BindableObject
    {

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public static bool IsLoggedIn { get; set; }
        public ICommand LoginCommand { get; } //LoginUser
                                              //Wala na GoToRegistration
                                              //public INavigation Navigation;
        public ConsumersLoginViewModel(/*INavigation navigation*/)
        {
            //Navigation = navigation;

            LoginCommand = new Command(async () => await PerformLogin());

            //Wala na GoToRegistration
        }
        private async Task PerformLogin()
        {
            var response = await ConsumerApiServices.ServiceClientInstance.LoginUser(Email, Password);

            if (response != null)
            {
                //await App.Current.MainPage.Navigation.PushAsync(new GeneralPublicPage(response.ConsumerUID.ToString()));
                await App.Current.MainPage.Navigation.PushAsync(new ConsumerTabbedPage(response.ConsumerUID.ToString()));
                //await Navigation.PushAsync(new GeneralPublicPage(response.ConsumerUID.ToString()));

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Server Error", "Ok");
            }

        }

        public bool IsConsumerLoggedIn()
        {
            if (PerformLogin().IsCompleted)
            {
                IsLoggedIn = true;
                return IsLoggedIn;
            }
            else
            {
                IsLoggedIn = false;
                return IsLoggedIn;
            }
        }

    }
}
