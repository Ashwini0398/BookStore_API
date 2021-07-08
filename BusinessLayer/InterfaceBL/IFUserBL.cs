using CommonLayer.Request;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.InterfaceBL
{
    public interface IFUserBL 
    {
        public UserResponse AddUser(UserRegistration userRequest);
        public bool LoginUser(UserLogin userLogin);
    }
}
