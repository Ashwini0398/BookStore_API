using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Response
{
    public class OrderResponse
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int CartID { get; set; }
        public int Quantity { get; set; }

    }
}
