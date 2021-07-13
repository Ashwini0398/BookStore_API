using CommonLayer.Request;
using CommonLayer.Response;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.InterfaceRL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.ServicesRL
{
    public class AdminRL : IAdminRL
    {
        private readonly IConfiguration _configuration;
        private SqlConnection conn;
        private void SQLConnection()
        {
            string sqlConnectionString = _configuration.GetConnectionString("myconn");
            conn = new SqlConnection(sqlConnectionString);
        }

        public AdminRL(IConfiguration configuration)
        {

            _configuration = configuration;
        }
        public AdminResponse AddUser(UserRegistration userRequest)
        {
            AdminResponse adminResponse = new AdminResponse();
            DateTime createDate = DateTime.Now;
            DateTime modifiedDate = DateTime.Now;

            SQLConnection();

            using (SqlCommand command = new SqlCommand("spAddUserDetail", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", userRequest.FirstName);
                command.Parameters.AddWithValue("@LastName", userRequest.LastName);
                command.Parameters.AddWithValue("@EmailID", userRequest.EmailId);
                command.Parameters.AddWithValue("@Password", userRequest.Password);
                command.Parameters.AddWithValue("@CreateDate", createDate);
                command.Parameters.AddWithValue("@ModifiedDate", modifiedDate);
                command.Parameters.AddWithValue("@UserCategory", "Admin");

                conn.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                adminResponse = RegistrationResponseModel(dataReader);
                conn.Close();
            };
            return adminResponse;
        }

        private AdminResponse RegistrationResponseModel(SqlDataReader dataReader)
        {
            try
            {
                AdminResponse responseData = null;
                while (dataReader.Read())
                {
                    responseData = new AdminResponse
                    {
                        AdminId = Convert.ToInt32(dataReader["UserID"]),
                        FirstName = dataReader["FirstName"].ToString(),
                        EmailId = dataReader["EmailID"].ToString(),
                        CreatedDate = Convert.ToDateTime(dataReader["CreateDate"])
                    };
                }
                return responseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AdminLoginResponse LoginUser(UserLogin userLogin)
        {
            AdminLoginResponse adminLoginResponse = new AdminLoginResponse();
            SQLConnection();
            using (SqlCommand command = new SqlCommand("spAdminLogin", conn))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@EmailID", userLogin.EmailId);
                command.Parameters.AddWithValue("@Password", userLogin.Password);


                conn.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                adminLoginResponse = LoginResponseModel(dataReader);
                conn.Close();
            };

            return adminLoginResponse;

        }

        private AdminLoginResponse LoginResponseModel(SqlDataReader dataReader)
        {
            try
            {
                AdminLoginResponse AdminLoginResponse = null;
                while (dataReader.Read())
                {
                    AdminLoginResponse = new AdminLoginResponse
                    {
                        AdminId = Convert.ToInt32(dataReader["UserID"]),
                        EmailId = dataReader["EmailID"].ToString(),
                    };
                }
                return AdminLoginResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
