﻿using System;
using BookApi.Models;

namespace BookApi.Interfaces
{
	public interface IBookService
	{
        IEnumerable<Book> GetAll();
        Book Add(Book newBook);
        Book GetById(Guid id);
        void Remove(Guid id);
    }
}

