using CommonLayer.Request;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.InterfaceRL
{
    public interface IFUserRL
    {
        public UserResponse AddUser(UserRegistration userRequest);
        public UserLoginResponse LoginUser(UserLogin userLogin);

    }
}
