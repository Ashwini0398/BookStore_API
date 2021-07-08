using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Response
{
    public class BookResponse
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class AllBookResponse
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
