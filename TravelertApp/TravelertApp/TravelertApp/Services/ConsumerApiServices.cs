using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelertApp.Models;
using Xamarin.Forms.Maps;

namespace TravelertApp.Services
{
    public class ConsumerApiServices
    {
        private JsonSerializer _serializer = new JsonSerializer();

        private static ConsumerApiServices _ServiceClientInstance;
        public static ConsumerApiServices ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new ConsumerApiServices();
                return _ServiceClientInstance;
            }
        }
        FirebaseClient firebase;
        public ConsumerApiServices()
        {
            //replace this with your firebase realtimedatabase end point.
            firebase = new FirebaseClient("https://travelertappdb-default-rtdb.firebaseio.com/");
        }

        #region ClientSection
        //[Pushing Single table to the Database]
        public async Task<bool> RegisterUser(string fullname, int age, string username, string email, string password, Position location)
        {
            var result = await firebase
                .Child("Consumers")
                .PostAsync(new Consumer() 
                {
                    FullName = fullname,
                    Age = age,
                    Username = username,
                    ConsumerUID = Guid.NewGuid(), 
                    Email = email, 
                    Password = password,
                    Location = location
                });

            if (result.Object != null)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        //Login with clients credentials. 
        public async Task<Consumer> LoginUser(string email, string password)
        {
            var getConsumer = (await firebase
              .Child("Consumers")
              .OnceAsync<Consumer>()).Where(a => a.Object.Email == email).Where(b => b.Object.Password == password).FirstOrDefault();

            if (getConsumer != null)
            {
                var content = getConsumer.Object as Consumer;
                return content;

            }
            else
            {
                return null;
            }
        }

        //Getting all consumers (gagamitin para sa GetConsumer) ??
        public async Task<List<Consumer>> GetAllConsumers()
        {
            var GetClients = (await firebase
               .Child("Consumers")
               .OnceAsync<Consumer>()).Select(item => new Consumer
               {
                   FullName = item.Object.FullName,
                   Age = item.Object.Age,
                   Username = item.Object.Username,
                   ConsumerUID = item.Object.ConsumerUID,
                   Email = item.Object.Email,
                   Password = item.Object.Password
               }).ToList();
            return GetClients;
        }

        //Getting the consumer??
        public async Task<Consumer> GetConsumer(string consumerUID)
        {
            var AllClients = await GetAllConsumers();

            await firebase
            .Child("Consumers")
            .OnceAsync<Consumer>();
            //.Where(a => a.Object.ConsumerUID.ToString() == consumerUID) //dinagdag ko 
            //.Select(item => new Consumer
            //{
            //    FullName = item.Object.FullName,
            //    Age = item.Object.Age,
            //    Username = item.Object.Username,
            //    ConsumerUID = item.Object.ConsumerUID,
            //    Email = item.Object.Email,
            //    Password = item.Object.Password
            //});
            return AllClients.Where(a => a.ConsumerUID.ToString() == consumerUID).FirstOrDefault();
        }

        //Logout the consumer?? sa mismong page.cs nalang

        #endregion ClientSection
    }
}
