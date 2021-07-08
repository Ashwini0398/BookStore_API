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
    public class SUserRL : IFUserRL 
    {
        private readonly IConfiguration _configuration;
        private SqlConnection conn;
        private void SQLConnection()
        {
            string sqlConnectionString = _configuration.GetConnectionString("myconn");
            conn = new SqlConnection(sqlConnectionString);
        }

        public SUserRL(IConfiguration configuration)
        {

            _configuration = configuration;
        }
        public UserResponse AddUser(UserRegistration userRequest) 
        {
            UserResponse userResponse = new UserResponse();
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

                conn.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                userResponse = RegistrationResponseModel(dataReader);
                conn.Close();
            };
            return userResponse;
        }

        public UserLoginResponse LoginUser(UserLogin userLogin)
        {
            UserLoginResponse userLoginResponse = new UserLoginResponse();
            SQLConnection();
            using (SqlCommand command = new SqlCommand("spUserLogin", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
             
                command.Parameters.AddWithValue("@EmailID", userLogin.EmailId);
                command.Parameters.AddWithValue("@Password", userLogin.Password);
                

                conn.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                userLoginResponse = LoginResponseModel(dataReader);
                conn.Close();
            };

            return userLoginResponse;
        }

        private UserResponse RegistrationResponseModel(SqlDataReader dataReader)
        {
            try
            {
                UserResponse responseData = null;
                while (dataReader.Read())
                {
                    responseData = new UserResponse
                    {
                        UserId = Convert.ToInt32(dataReader["UserID"]),
                        FirstName = dataReader["FirstName"].ToString(),
                        EmailId = dataReader["EmailID"].ToString(),
                        CreatedDate = Convert.ToDateTime(dataReader["CreateDate"])
                    };
                }
                return responseData;
            }
            catch (Exception ex)
            {
              throw  ex;
            }
        }

        private UserLoginResponse LoginResponseModel(SqlDataReader dataReader)
        {
            try
            {
                UserLoginResponse userLoginResponse = null;
                while (dataReader.Read())
                {
                    userLoginResponse = new UserLoginResponse
                    {                        
                        EmailId = dataReader["EmailID"].ToString(),
                        
                    };
                }
                return userLoginResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
