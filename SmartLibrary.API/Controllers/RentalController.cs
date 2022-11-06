using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartLibrary.API.Data;
using SmartLibrary.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {

        private readonly IRepository repository;
        public RentalController(IRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.repository.GetAllRentals();
            return Ok(result);
        }

        //// GET api/<RentalController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var rental = this.repository.GetRental(id);
            if(rental == null) return BadRequest("Rental not found");
            return Ok(rental);
        }

        // POST api/<RentalController>
        [HttpPost]
        public IActionResult Post(Rental rental)
        {
            this.repository.Add(rental);
            if (this.repository.SaveChanges())
            {
                return Ok(rental);
            }
            return BadRequest("Rental not found");
        }

        // PUT api/<RentalController>/5
        [HttpPut("{id}")]
        public IActionResult Post(int id, Rental rental)
        {
            var rent = this.repository.GetRental(id);
            if (rent == null) return BadRequest("Rental not found");

            this.repository.Update(rental);
            if (this.repository.SaveChanges())
            {
                return Ok(rental);
            }
            return BadRequest("Rental not found");
        }
        // PATCH api/<RentalController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Rental rental)
        {
            var rent = this.repository.GetRental(id);
            if (rent == null) return BadRequest("Rental not found");

            this.repository.Update(rental);
            if (this.repository.SaveChanges())
            {
                return Ok(rental);
            }
            return BadRequest("Rental not found");
        }

        // DELETE api/<RentalController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var rent = this.repository.GetRental(id);
            if (rent == null) return BadRequest("Rental not found");

            this.repository.Delete(rent);
            if (this.repository.SaveChanges())
            {
                return Ok("Rental deleted");
            }
            return BadRequest("Rental not found");
        }
    }
}
