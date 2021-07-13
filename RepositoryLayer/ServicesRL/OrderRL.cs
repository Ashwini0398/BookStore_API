using CommonLayer.Request;
using CommonLayer.Response;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.InterfaceRL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.ServicesRL
{
    public class OrderRL : IOrderRL
    {
        private readonly IConfiguration _configuration;
        private SqlConnection conn;

        public OrderRL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Sql Connection
        /// </summary>
        private void SQLConnection()
        {
            string sqlConnectionString = _configuration.GetConnectionString("myconn");
            conn = new SqlConnection(sqlConnectionString);
        }
        public OrderResponse PlaceOrder(int userID, OrderRequest CartID)
        {
            try
            {
                DateTime createDate = DateTime.Now;
                DateTime modifiedDate = createDate;

                OrderResponse responseData = null;
                SQLConnection();
                using (SqlCommand command = new SqlCommand("spPlaceOrder", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@CartID", CartID.CartID);
                    command.Parameters.AddWithValue("@BooksQuantity", CartID.Quantity);
                    command.Parameters.AddWithValue("@CreateDate", createDate);

                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    responseData = OrderResponseModel(dataReader);
                    conn.Close();
                };
                return responseData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private OrderResponse OrderResponseModel(SqlDataReader dataReader)
        {
            try
            {
                OrderResponse responseData = null;
                while (dataReader.Read())
                {
                    responseData = new OrderResponse
                    {
                        OrderID = Convert.ToInt32(dataReader["OrderID"]),
                        UserID = Convert.ToInt32(dataReader["UserID"]),
                        CartID = Convert.ToInt32(dataReader["CartID"]),
                        Quantity = Convert.ToInt32(dataReader["Quantity"]),

                    };
                }
                return responseData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       }
}
