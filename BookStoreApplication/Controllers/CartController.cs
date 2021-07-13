using BusinessLayer.Interface;
using CommonLayer.Request;
using Microsoft.AspNetCore.Authorization;
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
    public class CartController : ControllerBase
    {
        private ICartBL cartBL;
        public CartController(ICartBL _cartBL)
        {
            cartBL = _cartBL;
        }

        [Route("")]
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult AddCart(Cart cart)
        {
            try
            {
                var user = HttpContext.User;
                int userID = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);

                var result = cartBL.AddBookIntoCart(userID, cart);

                return this.Ok
                (new
                {
                    Data = result,
                    message = "Cart Successfully Added",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return this.BadRequest
                (new
                {
                    Data = new { ex },
                    message = "Book failed to Add",
                    Success = false
                });
            }

        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult GetAllCart()
        {
            try
            {
                var user = HttpContext.User;
                int userID = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);

                var result = cartBL.GetListOfBooksInCart(userID);

                return this.Ok
                (new
                {
                    Data = result,
                    message = "Get Cart All Details",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return this.BadRequest
                (new
                {
                    Data = new { ex },
                    message = "Fail to Get Cart All Details",
                    Success = false
                });
            }

        }

        [HttpDelete("{cartID}")]
        [Authorize(Roles = "User")]
        public IActionResult DeleteCart(int cartID)
        {
            try
            {
                var user = HttpContext.User;
                int userID = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);

                var result = cartBL.DeleteBookFromCart(userID, cartID);

                return this.Ok
                (new
                {
                    Data = result,
                    message = "Delete Cart Succesfully",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return this.Ok
                (new
                {
                    Data = new { ex },
                    message = "Fail to Delete Cart",
                    Success = false
                });
            }

        }
    }
}
