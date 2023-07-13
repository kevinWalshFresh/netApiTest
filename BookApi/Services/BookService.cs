using System;
using BookApi.Interfaces;
using BookApi.Models;

namespace BookApi.Data.Services
{
	public class BookService : IBookService
    {
		private readonly List<Book> _booksList;

		public BookService()
		{
			_booksList = BooksStore.booksList;
		}

		public IEnumerable<Book> GetAll()
		{
			return _booksList;
		}

		public Book Add(Book newBook)
		{
            newBook.Id = Guid.NewGuid();
			_booksList.Add(newBook);
			return newBook;
        }

		public Book GetById(Guid id)
		{
			return _booksList.FirstOrDefault(book => book.Id == id);
		}

		public void Remove(Guid id)
		{
			var bookToRemove = _booksList.FirstOrDefault(book => book.Id == id);
			_booksList.Remove(bookToRemove);
        }
	}
}

