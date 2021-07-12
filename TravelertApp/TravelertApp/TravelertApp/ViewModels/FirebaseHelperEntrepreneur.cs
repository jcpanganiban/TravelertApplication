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

namespace TravelertApp.ViewModels
{
    public class FirebaseHelperEntrepreneur
    {
        public static FirebaseClient firebase = new FirebaseClient("https://travelertappdb-default-rtdb.firebaseio.com/");

        //Read all consumers
        public static async Task<List<Entrepreneur>> GetAllUser()
        {
            try
            {
                var entrepreneurlist = (await firebase
                .Child("Entrepreneurs")
                .OnceAsync<Entrepreneur>()).Select(item =>
                new Entrepreneur
                {
                    FullName = item.Object.FullName,
                    Age = item.Object.Age,
                    BusinessType = item.Object.BusinessType,
                    Email = item.Object.Email

                }).ToList();
                return entrepreneurlist;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Something went wrong, please try again.\n{e.Message} {e.StackTrace}", "Ok");
                return null;
            }
        }

        //Retrieving consumers from the database
        public static async Task<Entrepreneur> GetUser(string email)
        {
            try
            {
                var allEntrepreneurs = await GetAllUser();
                await firebase
                .Child("Entrepreneurs")
                .OnceAsync<Entrepreneur>();

                return allEntrepreneurs.Where(a => a.Email == email).FirstOrDefault();
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Something went wrong, please try again.\n{e.Message} {e.StackTrace}", "Ok");
                return null;
            }
        }

        //Insert a consumer
        public static async Task<bool> AddEntrepreneur(string email, string password)
        {
            try
            {
                await firebase
                .Child("Entrepreneurs")
                .PostAsync(new Entrepreneur() { Email = email, Password = password });
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


                var toUpdateEntrepreneur = (await firebase
                .Child("Entrepreneurs")
                .OnceAsync<Entrepreneur>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase
                .Child("Entrepreneurs")
                .Child(toUpdateEntrepreneur.Key)
                .PutAsync(new Entrepreneur() { Email = email, Password = password });
                return true;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Something went wrong, please try again.\n{e.Message} {e.StackTrace}", "Ok");
                return false;
            }
        }

        //Deleting User(TO BE IMPLEMENTED SA XAMARIN FORMS KAYA NAKA COMMNENT)
        public static async Task<bool> DeleteUser(string email)
        {
            try
            {
                var toDeleteEntrepreneur = (await firebase
                .Child("Entrepreneurs")
                .OnceAsync<Entrepreneur>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase.Child("Entrepreneurs").Child(toDeleteEntrepreneur.Key).DeleteAsync();
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