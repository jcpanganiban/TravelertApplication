using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace TravelertApp.Models
{
    public class Consumer
    {

        public string FullName { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public Guid ConsumerUID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Position Location { get; set; }
        //public bool IsConsumer { get; set; }
    }
}
