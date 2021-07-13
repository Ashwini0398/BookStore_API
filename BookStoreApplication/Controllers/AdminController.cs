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
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAdminBL _adminBL;
        public AdminController(IAdminBL adminBL, IConfiguration configuration)
        {
            _adminBL = adminBL;
            _configuration = configuration;
        }

        [Route("Admin")]
        [HttpPost]
        public ActionResult AdminRegistration(UserRegistration userRequest)
        {
            try
            {
                var result = _adminBL.AddUser(userRequest);

                if (result == null)
                {
                    return this.BadRequest
                (new
                {
                    Data = new { },
                    message = "User Already Exist",
                    Success = false
                });

                }

                var response = new AdminResponse()
                {
                    AdminId = result.AdminId,
                    FirstName = result.FirstName,
                    EmailId = result.EmailId,
                    CreatedDate = result.CreatedDate
                };

                return this.Ok
                (new
                {
                    Data = response,
                    message = "Registration Successful",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return this.BadRequest
                (new
                {
                    Data = new { },
                    message = ex.Message,
                    Success = false
                });
                throw;
            }


        }

        [Route("AdminLogin")]
        [HttpPost]
        public ActionResult AdminLogin(UserLogin userLogin)
        {
            try
            {
                var result = _adminBL.LoginUser(userLogin);

                if (result == null)
                {
                    return this.BadRequest
                (new
                {
                    Data = new { },
                    message = "Invalid User",
                    Success = false
                });

                }

                AdminLoginResponse adminLoginResponse = new AdminLoginResponse()
                {
                    EmailId = result.EmailId,
                    AdminId = result.AdminId,
                    UserCatrgory = "Admin"
                };

                var token = GenerateToken(adminLoginResponse);
                return this.Ok
                (new
                {
                    Data = adminLoginResponse,
                    Token = token,
                    message = "Login Successful",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return this.BadRequest
                (new
                {
                    Data = new { },
                    message = ex.Message,
                    Success = false
                });
                throw;
            }
        }

        private string GenerateToken(AdminLoginResponse Info)
        {
            try
            {
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, Info.UserCatrgory),
                    new Claim("EmailID", Info.EmailId),
                    new Claim("AdminID", Info.AdminId.ToString())
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
