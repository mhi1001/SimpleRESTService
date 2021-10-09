using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookClassLibrary;
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
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _manager.GetAll(null);
        }

        // GET api/<BooksController>/BookName
        [HttpGet("{id}")]
        public IEnumerable<Book> Get(string substring)
        {
            return _manager.GetAll(substring);
        }

        // POST api/<BooksController>
        [HttpPost]
        public Book Post([FromBody] Book value)
        {
            return _manager.Add(value);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{isbn}")]
        public Book Put(string isbn, [FromBody] Book newBook)
        {
            return _manager.Update(isbn, newBook);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{isbn}")]
        public Book Delete(string isbn)
        {
            return _manager.Delete(isbn);
        }
    }
}
