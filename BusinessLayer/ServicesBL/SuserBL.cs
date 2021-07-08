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
    public class SuserBL : IFUserBL
    {
        public SuserBL(IFUserRL fUserRL) 
        {
            FUserRL = fUserRL;
        }

        private IFUserRL FUserRL;

        public UserResponse AddUser(UserRegistration userRequest) 
        {
            var result = FUserRL.AddUser(userRequest);

            return result;
        }

        public bool LoginUser(UserLogin userLogin)
        {
            FUserRL.LoginUser(userLogin);

            return true;
        }
    }
}
