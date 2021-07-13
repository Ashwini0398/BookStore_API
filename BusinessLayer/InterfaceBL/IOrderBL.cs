using CommonLayer.Request;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.InterfaceBL
{
    public interface IOrderBL
    {
        public OrderResponse PlaceOrder(int userID ,OrderRequest CartID);
    }
}
