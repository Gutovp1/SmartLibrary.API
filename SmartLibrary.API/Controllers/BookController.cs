using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartLibrary.API.Data;
using SmartLibrary.API.Dtos;
using SmartLibrary.API.Helper;
using SmartLibrary.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IRepository repository;
        private readonly IMapper mapper;

        public BookController(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpGet]
        
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var result = await this.repository.GetAllBooksAsync(pageParams);
            var bookResult = this.mapper.Map<IEnumerable<BookDto>>(result);
            Response.AddPagination(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
            return Ok(bookResult);
        }

        [HttpGet("available")]
        
        public async Task<IActionResult> GetAvailable([FromQuery] PageParams pageParams)
        {
            var result = await this.repository.GetAvailableBooksAsync(pageParams);
            var bookResult = this.mapper.Map<IEnumerable<BookDto>>(result);
            Response.AddPagination(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
            return Ok(bookResult);
        }
        //// GET api/<BookController>/5
        [HttpGet("{id}")]
        
        public IActionResult GetById(int id)
        {
            var book = this.repository.GetBook(id);
            if(book == null) return BadRequest("Book has not been found.");
            var bookDto = this.mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        // POST api/<BookController>
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public IActionResult Post(BookRegisterDto model)
        {
            var book = this.mapper.Map<Book>(model);
            this.repository.Add(book);
            if (this.repository.SaveChanges())
            {
                //return Ok(book);
                return Created($"/api/book/{model.Id}", this.mapper.Map<BookDto>(book));
            }
            return BadRequest("Book has not been found.");
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public IActionResult Put(int id, BookRegisterDto model)
        {
            var bk = this.repository.GetBook(id);
            if (bk == null) return BadRequest("Book has not been found.");
            int quantityRented = bk.Quantity - bk.QuantityAvailable;
            //if (this.repository.IsQuantityInvalid(bk)) return BadRequest("Quantity cannot be lower than the quantity of rented books.");
            if (model.Quantity < quantityRented) return BadRequest("Quantity cannot be lower than the quantity of rented books ("+ quantityRented+").");

            this.mapper.Map(model, bk);
            this.repository.Update(bk);
            if (this.repository.SaveChanges())
            {
                return Created($"/api/book/{model.Id}", this.mapper.Map<BookDto>(bk));
            }
            return BadRequest("Book has not been found.");
        }
        // PATCH api/<BookController>/5
        [HttpPatch("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public IActionResult Patch(int id, BookRegisterDto model)
        {
            var bk = this.repository.GetBook(id);
            if (bk == null) return BadRequest("Book has not been found.");

            this.mapper.Map(model, bk);
            this.repository.Update(bk);
            if (this.repository.SaveChanges())
            {
                return Created($"/api/book/{model.Id}", this.mapper.Map<BookDto>(bk));
            }
            return BadRequest("Book has not been found.");
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public IActionResult Delete(int id)
        {
            var bk = this.repository.GetBook(id);
            if (bk == null) return BadRequest("Book has not been found.");

            //if (this.repository.IsBookRented(bk)) return BadRequest("There are pending rentals for this book");
            if (bk.Quantity != bk.QuantityAvailable) return BadRequest("Book has not been deleted due to related pending rentals.");
            
            this.repository.Delete(bk);
            if (this.repository.SaveChanges())
            {
                return Ok("Book has been deleted successfully.");
            }
            return BadRequest("Book has not been found.");
        }
    }
}
