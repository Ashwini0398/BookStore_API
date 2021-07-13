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
    public class OrderController : ControllerBase
    {
        private IOrderBL _orderBL;
        public OrderController(IOrderBL orderBL)
        {
            _orderBL = orderBL;
        }

        [Route("")]
        [HttpPost]
        public ActionResult PlaceOrder(OrderRequest CartID )
        {
            try
            {
                var user = HttpContext.User;
                int userID = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);

                var result = _orderBL.PlaceOrder(userID, CartID);

                return this.Ok
                (new
                {
                    Data = result,
                    message = "Order placed",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return this.BadRequest
                (new
                {
                    Data = new { ex },
                    message = "Fail to Place the order",
                    Success = false
                });
            }

        }
    }
}
