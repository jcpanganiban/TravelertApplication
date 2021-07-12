using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelertApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelertApp.Views.ProfilePageUsers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntrepreneurProfilePage : ContentPage
    {
        private string EntrepreneurUID;

        public EntrepreneurProfilePage(string entrepreneurUID)
        {
            InitializeComponent();
            EntrepreneurUID = entrepreneurUID;

            GetEntrepreneurData();
        }
        private async void GetEntrepreneurData()
        {
            try
            {
                var response = await EntrepreneurApiServices.ServiceClientInstance.GetEntrepreneur(EntrepreneurUID);
                //Dito naten iseset ung value sa labels

                Lbl_FullName.Text = response.FullName;
                Lbl_Age.Text = response.Age.ToString();
                Lbl_BusinessType.Text = response.BusinessType;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"{ex.Message}\n{ex.StackTrace}", "Ok");
            }
        }

        private void Btn_Logout_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}