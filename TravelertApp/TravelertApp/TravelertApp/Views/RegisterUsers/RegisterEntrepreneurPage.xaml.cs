using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelertApp.Models;
using TravelertApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelertApp.Views.RegisterUsers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterEntrepreneurPage : ContentPage
    {
        public RegisterEntrepreneurPage()
        {
            InitializeComponent();
            BusinessType.Items.Add("Sole proprietorship");
            BusinessType.Items.Add("Partnerships");
            BusinessType.Items.Add("Limited liability company (LLC)");
            BusinessType.Items.Add("Corporation");

            BindingContext = new EntrepreneursSignUpVM();
        }

        private void BusinessType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}