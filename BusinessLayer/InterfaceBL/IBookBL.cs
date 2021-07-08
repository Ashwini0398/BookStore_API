using CommonLayer.Request;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.InterfaceBL
{
    public interface IBookBL
    {
        public BookResponse AddBook(BookRequest bookRequest);
        public List<AllBookResponse> GetAllBooks();
        public BookResponse UpdateBooks(int BooksId, BookRequest bookRequest);

        public bool DeleteBooks(int BookId);
    }
}
