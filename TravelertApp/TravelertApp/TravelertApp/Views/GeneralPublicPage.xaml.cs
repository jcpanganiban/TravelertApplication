using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelertApp.Models;
using TravelertApp.Services;
using TravelertApp.ViewModels;
using TravelertApp.Views.ProfilePageUsers;
using TravelertApp.Views.RegisterUsers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TravelertApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class GeneralPublicPage : ContentPage
    {

        private string ConsumerUID;
        private int userpinCount = 0;
        public GeneralPublicPage(string consumerUID)
        {
            InitializeComponent();
            ConsumerUID = consumerUID;
            BindingContext = new ConsumersMapViewModel();
            //consumersMapViewModel = new ConsumersMapViewModel(consumerUID);
            #region DesiredVehicle Picker
            //Calling DesiredVehicle picker to add elements
            DesiredVehicle.Items.Add("Class 1: Car, Jeepney, Van, Pickup, Motorcycle, Tricycle");
            DesiredVehicle.Items.Add("Class 2: Bus, Truck, Trailer Vehicle");
            DesiredVehicle.Items.Add("Class 3: Large Truck, Large Truck w/Trailer");
            DesiredVehicle.Items.Add("Train, Boat and Airplane");
            #endregion DesiredVehicle Picker

            Position center = new Position(14.598978831983539, 121.00537096699053);
            var pinLocations = new List<Position>();
            Pin consumerPin;

            //Pin pinPUP = new Pin()
            //{
            //    Type = PinType.Place,
            //    Label = "PUP CEA",
            //    Address = "Anonas, Sta. Mesa, Maynila, 1008 Kalakhang Maynila",
            //    Position = new Position(14.598978493230458d, 121.00537569264561d),
            //    Rotation = 33.3f,
            //    Tag = "id_tokyo",

            //};
            //map.Pins.Add(pinPUP);
            //map.MoveToRegion(MapSpan.FromCenterAndRadius(pinPUP.Position, Distance.FromMeters(5000)));
            GenPubMap.MoveToRegion(MapSpan.FromCenterAndRadius(center, Distance.FromMeters(500)));
            
            var response = ConsumerApiServices.ServiceClientInstance.GetConsumer(ConsumerUID);

            
            GenPubMap.MapClicked += async (sender, args) =>
            {
                //if (Btn_Confirm.IsPressed) { } d ko pa alam to kasi nabobobo ako 
                //await DisplayAlert("Coordinates", $"Lat: {args.Position.Latitude} Long: {args.Position.Longitude}", "Ok");


                Position positionClicked = new Position(args.Position.Latitude, args.Position.Longitude);
                consumerPin = new Pin()
                {
                    Position = positionClicked,
                    Label = "Other user location"
                };

                //Checking if the position exists in the firebase
                var responseLocationList = await FirebaseHelperConsumer.GetAllLocationsConsumer();
                foreach (var responseLocation in responseLocationList)
                {
                    //GenPubMap.Pins.Add(new Pin() { Position = new Position(responseLocation.Location.Latitude, responseLocation.Location.Longitude), Label = "Other user location" });
                    //await DisplayAlert("TRY", $"consumerPin: response.Result.Location: Lat: {responseLocation.Location.Latitude} \nLong: {responseLocation.Location.Longitude}", "OK");
                    if (responseLocation.Location.Latitude != 0 && responseLocation.Location.Longitude != 0)
                    {
                        userpinCount = 1;
                        await DisplayAlert("Alert", "You have already set your location", "OK");
                        break;
                    }
                    else if(responseLocation.Location.Latitude == 0 && responseLocation.Location.Longitude == 0)
                    {
                        userpinCount = 0;
                    }
                }



                if (userpinCount == 0 && !GenPubMap.Pins.Contains(consumerPin))
                {
                    GenPubMap.Pins.Add(consumerPin);
                    var consumerLocation = await FirebaseHelperConsumer.AddLocationConsumer(response.Result.FullName, response.Result.Age, response.Result.Username, response.Result.ConsumerUID, response.Result.Email, response.Result.Password, args.Position);
                    //await DisplayAlert("", $"consumerPin: response.Result.Location: Lat: {consumerLocation.Latitude} \nLong: {consumerLocation.Longitude}", "OK");
                    userpinCount++;
                }

                //Getting the Location
                //var responseLocationList = await FirebaseHelperConsumer.GetAllLocationsConsumer();
                //foreach (var responseLocation in responseLocationList)
                //{
                //    await DisplayAlert("TRY", $"consumerPin: response.Result.Location: Lat: {responseLocation.Location.Latitude} \nLong: {responseLocation.Location.Longitude}", "OK");
                //}

            };

            //Pag meron na (Count == 1), ang kailangan mangyare is idelete ung previous pin (ung nasa database bago iupdate)
            //Issue: Hindi tama ung pagreretrieve ng data mula sa database

            //Showing Pin Locations of all users (kaso d pa alam pano)
            GetConsumerPins();


            //Setting MyMenu to get the list of Menu
            //MyMenu = GetMenus();

            //Setting the binding contxt of this page to itself
            // - to bring the data from this page
            //this.BindingContext = this;

            #region GestureRecognizers

            //tapgesturerecognizer experiment
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

        //Kailangan muna d magzero ung response location
        private async void GetConsumerPins()
        {
            try
            {
                //var responseLocationList = await FirebaseHelperConsumer.GetAllLocationsConsumer();
                //foreach (var response in responseLocationList)
                //{
                //    GenPubMap.Pins.Add(new Pin() { Position = new Position(response.Location.Latitude, response.Location.Longitude), Label = "Other user location" });
                //    //await DisplayAlert("", $"consumerPin: response.Location: Lat: {response.Location.Latitude} \nLong: {response.Location.Longitude}", "OK");
                //}
                var responseLocationList = await FirebaseHelperConsumer.GetAllLocationsConsumer();
                foreach (var responseLocation in responseLocationList)
                {
                    GenPubMap.Pins.Add(new Pin() { Position = new Position(responseLocation.Location.Latitude, responseLocation.Location.Longitude), Label = "Other user location" });
                    //await DisplayAlert("TRY", $"consumerPin: response.Result.Location: Lat: {responseLocation.Location.Latitude} \nLong: {responseLocation.Location.Longitude}", "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"{ex.Message}\n{ex.StackTrace}", "Ok");
            }
        }

        private void DesiredVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}

