using BusinessLayer.InterfaceBL;
using CommonLayer.Request;
using CommonLayer.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        public User(IFUserBL userBL, IConfiguration configuration)
        {
            _userBL = userBL;
            _configuration = configuration;
        }

        private IConfiguration _configuration;
        private IFUserBL _userBL;
        [Route("Registration")]
        [HttpPost]
        public ActionResult userRegistration(UserRegistration userRequest) 
        {
            try
            {
                var result = _userBL.AddUser(userRequest);

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
                var result = _userBL.LoginUser(userLogin);

                UserLoginResponse userLoginResponse = new UserLoginResponse() {
                        EmailId = result.EmailId,
                        UserId = result.UserId,
                        UserCatrgory = "User"
                };

                var token = GenerateToken(userLoginResponse);
                return this.Ok
                (new
                {
                    Data = userLoginResponse,
                    Token = token,
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

        private string GenerateToken(UserLoginResponse Info)
        {
            try
            {
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, Info.UserCatrgory),
                    new Claim("EmailID", Info.EmailId),
                    new Claim("UserID", Info.UserId.ToString())
                };
                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                    _configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signingCreds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
    }
