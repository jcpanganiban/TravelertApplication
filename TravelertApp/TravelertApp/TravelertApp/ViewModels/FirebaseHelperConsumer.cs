using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TravelertApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TravelertApp.ViewModels
{
    public class FirebaseHelperConsumer
    {
        public static FirebaseClient firebase = new FirebaseClient("https://travelertappdb-default-rtdb.firebaseio.com/");

        //Read all consumers
        public static async Task<List<Consumer>> GetAllUser()
        {
            try
            {
                var consumerlist = (await firebase
                .Child("Consumers")
                .OnceAsync<Consumer>()).Select(item =>
                new Consumer
                {
                    FullName = item.Object.FullName,
                    Age = item.Object.Age,
                    Username = item.Object.Username,
                    Email = item.Object.Email,
                    Location = item.Object.Location

                }).ToList();
                return consumerlist;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Something went wrong, please try again.\n{e.Message} {e.StackTrace}", "Ok");
                return null;
            }
        }

        //Retrieving consumers from the database
        public static async Task<Consumer> GetUser(string email)
        {
            try
            {
                var allConsumers = await GetAllUser();
                await firebase
                .Child("Consumers")
                .OnceAsync<Consumer>();

                return allConsumers.Where(a => a.Email == email).FirstOrDefault();
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Something went wrong, please try again.\n{e.Message} {e.StackTrace}", "Ok");
                return null;
            }
        }

        //Insert a consumer
        public static async Task<bool> AddConsumer(string email, string password)
        {
            try
            {
                await firebase
                .Child("Consumers")
                .PostAsync(new Consumer() { Email = email, Password = password });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //TO BE IMPLEMENTED SA XAML:
        //Updating consumer(TO BE IMPLEMENTED SA XAMARIN FORMS KAYA NAKA COMMNENT)
        public static async Task<bool> UpdateUser(string email, string password)
        {
            try
            {


                var toUpdateConsumer = (await firebase
                .Child("Consumers")
                .OnceAsync<Consumer>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase
                .Child("Consumers")
                .Child(toUpdateConsumer.Key)
                .PutAsync(new Consumer() { Email = email, Password = password });
                return true;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Something went wrong, please try again.\n{e.Message} {e.StackTrace}", "Ok");
                return false;
            }
        }

        //Adding Location to the Database and Returning Location from the Database (Experimental)
        public static async Task<Position> AddLocationConsumer(string fullname, int age, string username, Guid consumerUID, string email, string password, Position location)
        {
            try
            {
                var toAddLocationConsumer = (await firebase
                .Child("Consumers")
                .OnceAsync<Consumer>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase
                .Child("Consumers")
                .Child(toAddLocationConsumer.Key)
                .PutAsync(new Consumer() { FullName = fullname, Age = age, Username = username, ConsumerUID = consumerUID, Email = email, Password = password, Location = location});
                return toAddLocationConsumer.Object.Location;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Something went wrong, please try again.\n{e.Message} {e.StackTrace}", "Ok");
                return new Position();
            }
        }

        //Getting All Location of the Users from the Database
        public static async Task<List<Consumer>> GetAllLocationsConsumer()
        {
            try
            {
                var consumerlocationlist = (await firebase
                .Child("Consumers")
                .OnceAsync<Consumer>()).Select(item =>
                new Consumer
                {
                    FullName = item.Object.FullName,
                    Age = item.Object.Age,
                    Username = item.Object.Username,
                    Email = item.Object.Email,
                    Location = item.Object.Location

                }).ToList();
                return consumerlocationlist;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Something went wrong, please try again.\n{e.Message} {e.StackTrace}", "Ok");
                return null;
            }
        }

        //Deleting User(TO BE IMPLEMENTED SA XAMARIN FORMS KAYA NAKA COMMNENT)
        public static async Task<bool> DeleteUser(string email)
        {
            try
            {
                var toDeleteConsumer = (await firebase
                .Child("Consumers")
                .OnceAsync<Consumer>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase.Child("Consumers").Child(toDeleteConsumer.Key).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Something went wrong, please try again.\n{e.Message} {e.StackTrace}", "Ok");
                return false;
            }
        }
    }
}
