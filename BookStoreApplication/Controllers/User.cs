using BusinessLayer.InterfaceBL;
using CommonLayer.Request;
using CommonLayer.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        public User(IFUserBL iFUserBL)
        {
            IfUserBL = iFUserBL;
        }

        private IFUserBL IfUserBL;
        [Route("Registration")]
        [HttpPost]
        public ActionResult userRegistration(UserRegistration userRequest) 
        {
            try
            {
                var result = IfUserBL.AddUser(userRequest);

                var response = new UserResponse()
                {
                    UserId = result.UserId,
                    FirstName = result.FirstName,
                    EmailId = result.EmailId,
                    CreatedDate = result.CreatedDate
                };

                return this.Ok
                (new {
                Data = response,
                message = "Registration Successful",
                Success = true
                });
            }
            catch (Exception)
            {
                return this.Ok
                (new
                {
                    Data = new { },
                    message = "Registration Fail",
                    Success = false
                });
                throw;
            }

            
        }
        [Route("login")]
        [HttpPost]
        public ActionResult userLogin(UserLogin userLogin)
        {
            try
            {
                IfUserBL.LoginUser(userLogin);

                var response = new UserLoginResponse()
                {
                    EmailId = userLogin.EmailId,
                  
                };

                return this.Ok
                (new
                {
                    Data = response,
                    message = "Login Successful",
                    Success = true
                });
            }
            catch (Exception )
            {
                return this.Ok
                (new
                {
                    Data = new { },
                    message = "Login Fail",
                    Success = false
                });
                throw;
            }
        }

        }
    }
