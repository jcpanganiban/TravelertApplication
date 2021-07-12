using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelertApp.Views.RegisterUsers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelertApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public static string userRole { get; set; }
        public RegisterPage()
        {
            InitializeComponent();

            //Calling my RegisterAs picker to add elements 
            RegisterAs.Items.Add("I am a consumer");
            RegisterAs.Items.Add("I am an entrepreneur");

        }

        private void RegisterAs_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        async private void Btn_Next_Clicked(object sender, EventArgs e)
        {
            //Getting the value that has been selected by the user by using indexer:
            var UserRoleSelected = RegisterAs.Items[RegisterAs.SelectedIndex];
            //if (UserRole == null) { }
            if (UserRoleSelected == RegisterAs.Items[0])
            {
                userRole = "Consumer";
                await Navigation.PushAsync(new RegisterGeneralPublicPage());
            }
            else if (UserRoleSelected == RegisterAs.Items[1])
            {
                userRole = "Entrepreneur";
                await Navigation.PushAsync(new RegisterEntrepreneurPage());
            }
            else
            {
                return;
            }
        }
    }
}