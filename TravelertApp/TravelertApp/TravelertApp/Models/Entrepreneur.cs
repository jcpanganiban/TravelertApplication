using System;
using System.Collections.Generic;
using System.Text;

namespace TravelertApp.Models
{
    public class Entrepreneur
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string BusinessType { get; set; }
        public Guid EntrepreneurUID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
