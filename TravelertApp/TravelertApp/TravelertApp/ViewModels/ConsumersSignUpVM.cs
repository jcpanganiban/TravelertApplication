using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelertApp.Services;
using TravelertApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TravelertApp.ViewModels
{
    public class ConsumersSignUpVM : BindableObject
    {
        private string fullname;
        public string FullName
        {
            get { return fullname; }
            set
            {
                fullname = value;
                OnPropertyChanged();
            }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged();
            }
        }
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }
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

        private string confirmpassword;
        public string ConfirmPassword
        {
            get { return confirmpassword; }
            set
            {
                confirmpassword = value;
                OnPropertyChanged();
            }
        }
        private Position location;
        public Position Location
        {
            get { return location; }
            set { location = value; }
        }
        public ICommand RegisterConsumer { get; }
        //public Command RegisterAsConsumerCommand
        //{
        //    get
        //    {
        //        return new Command(() =>
        //        {
        //            if (Password == ConfirmPassword)
        //                SignUp();
        //            else
        //                App.Current.MainPage.DisplayAlert("", "Password must be same as above!", "OK");
        //        });
        //    }
        //}
        public ConsumersSignUpVM()
        {
            RegisterConsumer = new Command(async () => await SetRegisterConsumer());
        }

        private async Task SetRegisterConsumer()
        {
            if (Password == ConfirmPassword)
            {
                var response = await ConsumerApiServices.ServiceClientInstance.RegisterUser(FullName, Age, Username, Email, Password, Location);
                if (response == true)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "User Created Sucessfully", "Ok");
                    App.Current.MainPage = new NavigationPage(new LoginConsumerPage());

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Register Consumer Failed", "Ok");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Confirm Password must match the password", "Ok");
            }


        }

            
        
    }
}
