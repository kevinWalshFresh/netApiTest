using System;
using BookApi.Interfaces;
using BookApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private readonly IBookService _service;

		public BookController(IBookService service)
		{
			_service = service;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Book>> GetAllBooks()
		{
			var books = _service.GetAll();
			return Ok(books);
		}

		[HttpGet("{id}")]
		public ActionResult<Book> GetBook(Guid id)
		{
			var book = _service.GetById(id);
			if (book == null)
			{
				return NotFound();
			}

			return Ok(book);
		}

		[HttpPost]
		public ActionResult AddBook([FromBody] Book book)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var newBook = _service.Add(book);
			return CreatedAtAction("GetBook", new { id = newBook.Id }, newBook);
		}

        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var existingItem = _service.GetById(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            _service.Remove(id);
            return Ok();
        }
    }
}

