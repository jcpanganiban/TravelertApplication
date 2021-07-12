using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelertApp.Views.ProfilePageUsers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelertApp.Views.TabbedPageUsers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntrepreneurTabbedPage : TabbedPage
    {
        private string EntrepreneurUID;
        public EntrepreneurTabbedPage(string entrepreneurUID)
        {
            InitializeComponent();

            EntrepreneurUID = entrepreneurUID;

            Children.Add(new EntrepreneurPage(EntrepreneurUID) { Title = "Home", IconImageSource = "home.png" });
            Children.Add(new EntrepreneurProfilePage(EntrepreneurUID) { Title = "Profile", IconImageSource = "user.png" });
            Children.Add(new EntrepreneurSettingsPage(EntrepreneurUID) { Title = "Settings", IconImageSource = "settings.png" });
        }
    }
}