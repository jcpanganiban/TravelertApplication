using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelertApp.Models;

namespace TravelertApp.Services
{
    public class EntrepreneurApiServices
    {
        private JsonSerializer _serializer = new JsonSerializer();

        private static EntrepreneurApiServices _ServiceClientInstance;
        public static EntrepreneurApiServices ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new EntrepreneurApiServices();
                return _ServiceClientInstance;
            }
        }
        FirebaseClient firebase;
        public EntrepreneurApiServices()
        {
            //replace this with your firebase realtimedatabase end point.
            firebase = new FirebaseClient("https://travelertappdb-default-rtdb.firebaseio.com/");
        }

        #region ClientSection
        //[Pushing Single table to the Database]
        public async Task<bool> RegisterUser(string fullname, int age, string businesstype, string email, string password)
        {
            var result = await firebase
                .Child("Entrepreneurs")
                .PostAsync(new Entrepreneur()
                {
                    FullName = fullname,
                    Age = age,
                    BusinessType = businesstype,
                    EntrepreneurUID = Guid.NewGuid(),
                    Email = email,
                    Password = password
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
        public async Task<Entrepreneur> LoginUser(string email, string password)
        {
            var getEntrepreneur = (await firebase
              .Child("Entrepreneurs")
              .OnceAsync<Entrepreneur>()).Where(a => a.Object.Email == email).Where(b => b.Object.Password == password).FirstOrDefault();

            if (getEntrepreneur != null)
            {
                var content = getEntrepreneur.Object as Entrepreneur;
                return content;

            }
            else
            {
                return null;
            }
        }

        //Getting all entrepreneurs (gagamitin para sa GetEntrepreneur) ??
        public async Task<List<Entrepreneur>> GetAllEntrepreneurs()
        {
            var GetClients = (await firebase
               .Child("Entrepreneurs")
               .OnceAsync<Entrepreneur>()).Select(item => new Entrepreneur
               {
                   FullName = item.Object.FullName,
                   Age = item.Object.Age,
                   BusinessType = item.Object.BusinessType,
                   EntrepreneurUID = item.Object.EntrepreneurUID,
                   Email = item.Object.Email,
                   Password = item.Object.Password
               }).ToList();
            return GetClients;
        }

        //Getting the entrepreneur??
        public async Task<Entrepreneur> GetEntrepreneur(string entrepreneurUID)
        {
            var AllClients = await GetAllEntrepreneurs();

            await firebase
            .Child("Entrepreneurs")
            .OnceAsync<Entrepreneur>();
            return AllClients.Where(a => a.EntrepreneurUID.ToString() == entrepreneurUID).FirstOrDefault();
        }

        //Logout the entrepreneur?? sa mismong page.cs nalang

        #endregion ClientSection
    }
}
