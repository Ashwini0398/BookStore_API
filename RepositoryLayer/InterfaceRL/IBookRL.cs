using CommonLayer.Request;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.InterfaceRL
{
    public interface IBookRL
    {
        public BookResponse AddBook(BookRequest bookRequest);
        public List<AllBookResponse> GetAllBooks();
        public BookResponse UpdateBooks(int BooksId, BookRequest data);
        public bool DeleteBooks(int BookId);

    }
}
