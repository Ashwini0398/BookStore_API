using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Response
{
     public class AdminResponse
    {
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string EmailId { get; set; }

        public DateTime CreatedDate { get; set; }
    }

    public class AdminLoginResponse
    {
        public int AdminId { get; set; }
        public string EmailId { get; set; }
        public string UserCatrgory { get; set; }
    }

}
