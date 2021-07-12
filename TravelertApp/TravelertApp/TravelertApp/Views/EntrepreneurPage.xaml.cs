using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelertApp.Views.ProfilePageUsers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelertApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class EntrepreneurPage : ContentPage
    {
        private string EntrepreneurUID;

        public EntrepreneurPage(string entrepreneurUID)
        {
            InitializeComponent();
            EntrepreneurUID = entrepreneurUID;

            //MyMenu = GetMenus();
            //this.BindingContext = this; 
        }

        //public List<EntrepMenu> MyMenu { get; set; }
        //private List<EntrepMenu> GetMenus()
        //{
        //    return new List<EntrepMenu>
        //    {
        //        new EntrepMenu{Name = "Home", Icon = "home.png" },
        //        new EntrepMenu{Name = "Profile", Icon = "user.png"},
        //        new EntrepMenu{Name = "Settings", Icon = "settings.png"},
        //    };

        //}
    }

    //public class EntrepMenu
    //{
    //    public string Name { get; set; }
    //    public string Icon { get; set; }
    //}
}

