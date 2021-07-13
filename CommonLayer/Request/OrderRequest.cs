using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Request
{
    public class OrderRequest
    {
        public int CartID { get; set; }
        public int Quantity { get; set; }
    }
}
