﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Responce
{
    public class WishListResponse
    {
        public int WishListID { get; set; }

        public int UserID { get; set; }

        public int BookID { get; set; }

        public string BookName { get; set; }

        public string Author { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public string Image { get; set; }
    }
}
