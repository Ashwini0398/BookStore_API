using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Request
{
    public class BookRequest
    {
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Discription { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
    }
}
