using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Request
{
    public class UserRegistration
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
     
    public class UserLogin
    {
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
