using CommonLayer.Request;
using CommonLayer.Responce;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IWishListBL
    {
        public WishListResponse CreateNewWishList(int userID, WishList data);

        public List<WishListResponse> GetListOfWishList(int userID);

        public CartBookResponse MoveToCart(int userID, Wish_List data);

        public bool DeleteBookFromWishList(int userID, int wishListID);

    }
}
