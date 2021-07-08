using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Responce
{
    public class CartBookResponse
    {
        public int UserID { get; set; }

        public int CartID { get; set; }

        public int BookID { get; set; }

        public string BookName { get; set; }

        public string Author { get; set; }

        public int Price { get; set; }

        public string Image { get; set; }
    }
}
