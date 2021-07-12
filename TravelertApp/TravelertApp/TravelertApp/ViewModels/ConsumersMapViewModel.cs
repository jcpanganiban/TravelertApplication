using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TravelertApp.ViewModels
{
    public class ConsumersMapViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string fullname;
        public string FullName
        {
            get { return fullname; }
            set
            {
                fullname = value;
                //OnPropertyChanged();
            }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                //OnPropertyChanged();
            }
        }
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                //OnPropertyChanged();
            }
        }
        private Guid consumerUID;
        public Guid ConsumerUID
        {
            get { return consumerUID; }
            set
            {
                consumerUID = value;
                //OnPropertyChanged();
            }
        }
        private string email;
        public string Email 
        {
            get { return email; } 
            set { email = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                //PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        private Position location;
        public Position Location
        {
            get { return location; }
            set
            {
                location = value;
                //PropertyChanged(this, new PropertyChangedEventArgs("Location"));
            }
        }
        public Command AddLocationCommand //Magrurun lang to after maclick ni user ung map.
        {
            get { return new Command(AddLocation); }
        }
        private async void AddLocation()
        {
            try
            {
                if (!string.IsNullOrEmpty(Location.Latitude.ToString()) || !string.IsNullOrEmpty(Location.Longitude.ToString()))
                {
                    await FirebaseHelperConsumer.AddLocationConsumer(FullName, Age, Username, ConsumerUID, Email, Password, Location);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Select your location", "Ok");
                }
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", $"Something went wrong, please try again. {ex.Message}\n{ex.StackTrace}", "Ok"); //GAGAWIN IS IBIBIND AT GAGAMITIN UNG COMMAND
            }
        }
    }
}
