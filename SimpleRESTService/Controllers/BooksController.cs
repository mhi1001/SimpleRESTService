using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using BookClassLibrary;
using Microsoft.AspNetCore.Http;
using SimpleRESTService.Manager;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleRESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksManager _manager = new BooksManager();

        // GET: api/<BooksController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            IEnumerable<Book> books = _manager.GetAll(null);

            if (books == null || !books.Any())
            {
                return NotFound("No Books found");
            }

            return Ok(books);

        }

        // GET api/<BooksController>/BookName
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{substring}")]
        public ActionResult<IEnumerable<Book>> Get(string substring)
        {
            IEnumerable<Book> books = _manager.GetAll(substring);

            if (books == null || !books.Any())
            {
                return NotFound("No Books found with this name");
            }

            return Ok(books);
        }


        // POST api/<BooksController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book value)
        {
            Book book = _manager.Add(value);
            if (book == null)
            {
                return BadRequest("Data was null");
            }

            return Ok(book);
        }

        // PUT api/<BooksController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{isbn}")]
        public ActionResult<Book> Put(string isbn, [FromBody] Book newBook)
        {
            Book book = _manager.Update(isbn, newBook);
            if (book == null)
            {
                return BadRequest("Data was null");
            }

            return Ok(book);
        }

        // DELETE api/<BooksController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{isbn}")]
        public ActionResult<Book> Delete(string isbn)
        {
            Book book = _manager.Delete(isbn);
            if (book == null)
            {
                return BadRequest("Data was null");
            }
            return Ok(book);
        }
    }
}
