using BusinessLayer.Interface;
using CommonLayer.Request;
using CommonLayer.Responce;
using CommonLayer.Response;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class WishListBL : IWishListBL
    {
        private readonly IWishListRL _wishListRL;

        public WishListBL(IWishListRL wishList)
        {
            _wishListRL = wishList;
        }

        public WishListResponse CreateNewWishList(int userID, WishList data)
        {
            try
            {
                if (userID <= 0 || data == null)
                {
                    return null;
                }
                else
                {
                    return _wishListRL.CreateNewWishList(userID, data);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<WishListResponse> GetListOfWishList(int userID)
        {
            try
            {
                if (userID <= 0 )
                {
                    return null;
                }
                else
                {
                    return _wishListRL.GetListOfWishList(userID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteBookFromWishList(int userID, int wishListID)
        {
            try
            {
                if (userID <= 0 )
                {
                    return false;
                }
                else
                {
                    return _wishListRL.DeleteBookFromWishList(userID, wishListID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public CartBookResponse MoveToCart(int userID, Wish_List data)
        {
            try
            {
                if (userID <= 0 && data != null )
                {
                    return null;
                }
                else
                {
                    return _wishListRL.MoveToCart(userID, data);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
