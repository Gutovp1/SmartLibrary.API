using Microsoft.AspNetCore.Mvc;
using SmartLibrary.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        public List<Rental> Rentals = new List<Rental>()
        {
            new Rental()
            {
                Id = 1,
                BookId = 1,
                UserId = 1
            },
            new Rental()
            {
                Id = 2,
                BookId = 2,
                UserId = 2
            },
            new Rental()
            {
                Id = 3,
                BookId = 3,
                UserId = 3
            },
            new Rental()
            {
                Id = 4,
                BookId = 4,
                UserId = 4
            },
        };
        public RentalController()
        {

        }

        // GET: api/<RentalController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Rentals);
        }

        //// GET api/<RentalController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var rental = Rentals.FirstOrDefault(a => a.Id == id);
            if(rental == null) return BadRequest("Rental not found");
            return Ok(rental);
        }

        // POST api/<RentalController>
        [HttpPost]
        public IActionResult Post(Rental rental)
        {
            return Ok(rental);
        }

        // PUT api/<RentalController>/5
        [HttpPut("{id}")]
        public IActionResult Post(int id, Rental rental)
        {
            return Ok(rental);
        }

        // DELETE api/<RentalController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             return Ok();
        }
    }
}
