using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartLibrary.API.Data;
using SmartLibrary.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IRepository repository;
        public BookController(IRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.repository.GetAllBooksAsync();
            return Ok(result);
        }

        //// GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = this.repository.GetBook(id);
            if(book == null) return BadRequest("Book not found");
            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post(Book book)
        {
            this.repository.Add(book);
            if (this.repository.SaveChanges())
            {
                return Ok(book);
            }
            return BadRequest("Book not found");
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Post(int id, Book book)
        {
            var bk = this.repository.GetBook(id);
            if (bk == null) return BadRequest("Book not found");

            this.repository.Update(book);
            if (this.repository.SaveChanges())
            {
                return Ok(book);
            }
            return BadRequest("Book not found");
        }
        // PATCH api/<BookController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Book book)
        {
            var bk = this.repository.GetBook(id);
            if (bk == null) return BadRequest("Book not found");

            this.repository.Update(book);
            if (this.repository.SaveChanges())
            {
                return Ok(book);
            }
            return BadRequest("Book not found");
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bk = this.repository.GetBook(id);
            if (bk == null) return BadRequest("Book not found");

            this.repository.Delete(bk);
            if (this.repository.SaveChanges())
            {
                return Ok("Book deleted");
            }
            return BadRequest("Book not found");
        }
    }
}
