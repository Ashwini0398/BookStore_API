using CommonLayer.Request;
using CommonLayer.Responce;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        public List<CartBookResponse> GetListOfBooksInCart(int userID);
        public bool DeleteBookFromCart(int userID, int cartID);
        public CartBookResponse AddBookIntoCart(int userID, Cart data);

    }
}
