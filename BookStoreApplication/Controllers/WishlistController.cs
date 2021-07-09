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
    public class WishlistController : ControllerBase
    {
        private IWishListBL wishList;
        public WishlistController(IWishListBL wishlistBL)
        {
            wishList = wishlistBL;
        }

        [Route("")]
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult AddWishList(WishList wishlist)
        {
            try
            {
                var user = HttpContext.User;
                int userID = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);

                var result = wishList.CreateNewWishList(userID, wishlist);

                return this.Ok
                (new
                {
                    Data = result,
                    message = "WishList Successfully Added",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return this.Ok
                (new
                {
                    Data = new { ex },
                    message = "Wishlist  failed to Add",
                    Success = false
                });
            }

        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult GetAllWishList()
        {
            try
            {
                var user = HttpContext.User;
                int userID = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);

                var result = wishList.GetListOfWishList(userID);

                return this.Ok
                (new
                {
                    Data = result,
                    message = "Get WishList All Details",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return this.Ok
                (new
                {
                    Data = new { ex },
                    message = "Fail to Get WishList All Details",
                    Success = false
                });
            }

        }
        [Route("MoveToCart")]
        [HttpPost]
        public ActionResult MoveWishListToCart(Wish_List wishlist)
        {
            try
            {
                var user = HttpContext.User;
                int userID = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);

                var result = wishList.MoveToCart(userID,wishlist);

                return this.Ok
                (new
                {
                    Data = result,
                    message =  "Move WishList Details to Cart",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return this.Ok
                (new
                {
                    Data = new { ex },
                    message = "Fail to Move WishList Details to Cart",
                    Success = false
                });
            }

        }

        [HttpDelete("{WishListID}")]
        [Authorize(Roles = "User")]
        public IActionResult DeleteCart(int WishListID)
        {
            try
            {
                var user = HttpContext.User;
                int userID = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);

                var result = wishList.DeleteBookFromWishList(userID, WishListID);

                return this.Ok
                (new
                {
                    Data = result,
                    message = "Delete WishList Succesfully",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return this.Ok
                (new
                {
                    Data = new { ex },
                    message = "Fail to Delete WishList",
                    Success = false
                });
            }

        }
    }
}
