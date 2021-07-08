using CommonLayer.Request;
using CommonLayer.Responce;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IWishListRL
    {
        public WishListResponse CreateNewWishList(int userID, WishList data);

        public List<WishListResponse> GetListOfWishList(int userID);

        public bool DeleteBookFromWishList(int userID, int wishListID);

        public CartBookResponse MoveToCart(int userID, Wish_List data);
    }
}
