using CommonLayer.Request;
using CommonLayer.Responce;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface ICartRL
    {
        public CartBookResponse AddBookIntoCart(int userID, Cart data);

        public List<CartBookResponse> GetListOfBooksInCart(int userID);

        public bool DeleteBookFromCart(int userID, int cartID);

    }
}
