using BusinessLayer.InterfaceBL;
using CommonLayer.Request;
using CommonLayer.Response;
using RepositoryLayer.InterfaceRL;
using RepositoryLayer.ServicesRL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ServicesBL
{
    public class AdminBL : IAdminBL
    {
        private readonly IAdminRL adminRL;
        public AdminBL(IAdminRL sadminRL)
        {
            adminRL = sadminRL;
        }
        public AdminResponse AddUser(UserRegistration userRequest)
        {
            var result = adminRL.AddUser(userRequest);

            return result;
        }

        public AdminLoginResponse LoginUser(UserLogin userLogin)
        {
            var result = adminRL.LoginUser(userLogin);

            return result;
        }
    }
}
