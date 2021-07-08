using BusinessLayer.InterfaceBL;
using CommonLayer.Request;
using CommonLayer.Response;
using RepositoryLayer.InterfaceRL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ServicesBL
{
    public class SBookBL : IBookBL
    {
        private IBookRL bookRL;
        public SBookBL(IBookRL bookRL)
        {
           this.bookRL = bookRL;
        }

        public BookResponse AddBook(BookRequest bookRequest)
        {
           var result = this.bookRL.AddBook(bookRequest);
            return result;
        }
        public List<AllBookResponse> GetAllBooks()
        {
            try
            {
                return  this.bookRL.GetAllBooks();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BookResponse UpdateBooks(int BooksId, BookRequest bookRequest)
        {
            try
            {
                if (bookRequest == null)
                    return null;
                else
                    return this.bookRL.UpdateBooks(BooksId, bookRequest);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteBooks(int BookId)
        {
            return this.bookRL.DeleteBooks(BookId);
        }




    }
}
