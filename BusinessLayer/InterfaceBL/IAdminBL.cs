using CommonLayer.Request;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.InterfaceBL
{
     public interface IAdminBL
    {
        public AdminResponse AddUser(UserRegistration userRequest);
        public AdminLoginResponse LoginUser(UserLogin userLogin);
    }
}
