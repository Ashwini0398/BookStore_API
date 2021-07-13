using BusinessLayer.InterfaceBL;
using CommonLayer.Request;
using CommonLayer.Response;
using RepositoryLayer.InterfaceRL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ServicesBL
{
    public class OrderBL : IOrderBL
    {
        private IOrderRL _orderRL;
        public OrderBL(IOrderRL orderRL)
        {
            _orderRL = orderRL;
        }

        public OrderResponse PlaceOrder(int userID, OrderRequest CartID)
        {
            try
            {
                if (CartID.CartID > 0)
                {
                    return _orderRL.PlaceOrder(userID, CartID);
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
