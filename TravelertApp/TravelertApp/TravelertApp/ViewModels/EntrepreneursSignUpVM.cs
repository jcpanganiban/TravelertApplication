using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelertApp.Services;
using TravelertApp.Views;
using Xamarin.Forms;
namespace TravelertApp.ViewModels
{
    public class EntrepreneursSignUpVM : BindableObject
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
        private string selectedbusinessType;
        public string SelectedBusinessType
        {
            get { return selectedbusinessType; }
            set
            {
                selectedbusinessType = value;
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
        public ICommand RegisterEntrepreneur { get; }

        public EntrepreneursSignUpVM()
        {
            RegisterEntrepreneur = new Command(async () => await SetRegisterEntrepreneur());
        }

        private async Task SetRegisterEntrepreneur()
        {
            if (Password == ConfirmPassword)
            {
                var response = await EntrepreneurApiServices.ServiceClientInstance.RegisterUser(FullName, Age, SelectedBusinessType, Email, Password);
                if (response == true)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "User Created Sucessfully", "Ok");
                    App.Current.MainPage = new NavigationPage(new LoginEntrepreneurPage());

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Register Entrepreneur Failed", "Ok");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Confirm Password must match the password", "Ok");
            }


        }
    }
}
