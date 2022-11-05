using Microsoft.AspNetCore.Mvc;
using SmartLibrary.API.Data;
using SmartLibrary.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly SmartContext context;
        public RentalController(SmartContext  context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.context.Rentals);
        }

        //// GET api/<RentalController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var rental = this.context.Rentals.FirstOrDefault(a => a.Id == id);
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
