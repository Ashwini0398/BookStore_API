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

    public class SBookRL : IBookRL
    {
        private readonly IConfiguration _configuration;
        private SqlConnection conn;
        private void SQLConnection()
        {
            string sqlConnectionString = _configuration.GetConnectionString("myconn");
            conn = new SqlConnection(sqlConnectionString);
        }

        public SBookRL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public BookResponse AddBook(BookRequest bookRequest)
        {
            BookResponse bookResponse = new BookResponse();

            SQLConnection();

            using (SqlCommand command = new SqlCommand("spAddBooks", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookName", bookRequest.BookName);
                command.Parameters.AddWithValue("@Author", bookRequest.Author);
                command.Parameters.AddWithValue("@Description", bookRequest.Discription);
                command.Parameters.AddWithValue("@Quantity", bookRequest.Quantity);
                command.Parameters.AddWithValue("@Price", bookRequest.Price);
                command.Parameters.AddWithValue("@CreateDate", DateTime.Now);

                conn.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                bookResponse = AddBooksResponseModel(dataReader);
                conn.Close();
            };


            return bookResponse;
        }

        public List<AllBookResponse> GetAllBooks() 
        {
            try
            {
                List<AllBookResponse> bookList = null;
                SQLConnection();
                bookList = new List<AllBookResponse>();
                using (SqlCommand command = new SqlCommand("spGetBooks", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    bookList = ListBookResponseModel(dataReader);
                    conn.Close();
                };
                return bookList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BookResponse UpdateBooks(int BooksId, BookRequest data)
        {
            try
            {
                BookResponse responseData = null;

                SQLConnection();

                using (SqlCommand command = new SqlCommand("spUpdateBookById", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookID", BooksId);
                    command.Parameters.AddWithValue("@BookName", data.BookName);
                    command.Parameters.AddWithValue("@AuthorName", data.Author);
                    command.Parameters.AddWithValue("@Price", data.Price);
                    command.Parameters.AddWithValue("@Quantity", data.Quantity);
                    command.Parameters.AddWithValue("@Description", data.Discription);
                    command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    responseData = AddBooksResponseModel(dataReader);
                    conn.Close();
                };
                return responseData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteBooks(int BooksId)
        {
            try
            {

                SQLConnection();

                using (SqlCommand command = new SqlCommand("spDeleteBookById", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookID", BooksId);
                    command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                    conn.Open();
                   var count = command.ExecuteNonQuery();
                   if(count >= 0)
                    {
                        conn.Close();
                        return true;
                    }
                    
                    conn.Close();
                };
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<AllBookResponse> ListBookResponseModel(SqlDataReader dataReader)
        {
            try
            {
                List<AllBookResponse> bookList = new List<AllBookResponse>();
                AllBookResponse responseData = null;
                while (dataReader.Read())
                {
                    responseData = new AllBookResponse
                    {
                        BookID = Convert.ToInt32(dataReader["BookID"]),
                        BookName = dataReader["BookName"].ToString(),
                        Author = dataReader["Author"].ToString(),
                        Description = dataReader["Description"].ToString(),
                        Price = dataReader["Price"].ToString(),
                        Quantity = Convert.ToInt32(dataReader["Quantity"]),
                        Image = dataReader["BookImage"].ToString()
                    };
                    bookList.Add(responseData);
                }
                return bookList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private BookResponse AddBooksResponseModel(SqlDataReader dataReader)
        {
            try
            {
                BookResponse responseData = null;
                while (dataReader.Read())
                {
                    responseData = new BookResponse
                    {
                        BookID = Convert.ToInt32(dataReader["BookID"]),
                        BookName = dataReader["BookName"].ToString(),
                        Price = dataReader["Price"].ToString(),
                        CreatedDate = Convert.ToDateTime(dataReader["CreateDate"])
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
