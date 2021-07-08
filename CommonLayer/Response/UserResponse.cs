using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Response
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string EmailId { get; set; }

        public DateTime CreatedDate { get; set; }
    }

    public class UserLoginResponse
    {
        public string EmailId { get; set; }
        
    }
}
