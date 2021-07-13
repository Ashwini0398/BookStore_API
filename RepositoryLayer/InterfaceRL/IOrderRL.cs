using CommonLayer.Request;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.InterfaceRL
{
    public interface IOrderRL
    {
        public OrderResponse PlaceOrder(int userID,OrderRequest CartID);
    }
}

