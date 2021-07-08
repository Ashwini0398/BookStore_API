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
    public class Books : ControllerBase
    {
        private IBookBL bookBL;
        public Books(IBookBL book)
        {
            bookBL = book;
        }
       
        [HttpPost]
        public ActionResult AddBook(BookRequest bookRequest)
        {
            try
            {
                var result = bookBL.AddBook(bookRequest);

                var response = new BookResponse()
                {
                    BookID = result.BookID,
                    BookName = result.BookName,
                    Price = result.Price,
                    CreatedDate = result.CreatedDate
                };

                return this.Ok
                (new
                {
                    Data = response,
                    message = "Book Successfully Added",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return this.Ok
                (new
                {
                    Data = new { },
                    message = "Book failed to Add",
                    Success = false
                });               
            }

        }

        
        [HttpGet]
        public ActionResult GetBook()
        {
            try
            {
                var result = bookBL.GetAllBooks();

                return this.Ok
                (new
                {
                    Data = result,
                    message = "Get All Book Successfully",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return this.Ok
                (new
                {
                    Data = new { },
                    message = "Book failed to Add",
                    Success = false
                });                
            }

        }
        [Route("{BookId}")]
        [HttpPut]
        public ActionResult UpdateBooks(int BookId, BookRequest bookRequest)
        {
            try
            {
                
                var data = bookBL.UpdateBooks(BookId, bookRequest);

                return this.Ok
                (new
                {
                    Data = data,
                    message = "Update Book Successfully",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [Route("{BookId}")]
        [HttpDelete]
        public ActionResult DeleteBooks(int BookId)
        {
            try
            {

                var data = bookBL.DeleteBooks(BookId);

                return this.Ok
                (new
                {
                    Data = data,
                    message = " Book Deleted Successfully",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }



    }
}
