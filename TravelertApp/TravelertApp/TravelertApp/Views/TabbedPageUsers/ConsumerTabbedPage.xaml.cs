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
    public partial class ConsumerTabbedPage : TabbedPage
    {
        private string ConsumerUID;
        public ConsumerTabbedPage(string consumerUID)
        {
            InitializeComponent();

            ConsumerUID = consumerUID;

            Children.Add(new GeneralPublicPage(ConsumerUID) { Title = "Home", IconImageSource = "home.png" });
            Children.Add(new ConsumerProfilePage(ConsumerUID) { Title = "Profile", IconImageSource = "user.png" });
            Children.Add(new ConsumerSettingsPage(ConsumerUID) { Title = "Settings", IconImageSource = "settings.png" });
        }
    }
}