using CommonLayer.Request;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.InterfaceRL
{
     public interface IAdminRL
    {
        public AdminResponse AddUser(UserRegistration userRequest);
        public AdminLoginResponse LoginUser(UserLogin userLogin);
    }
}
