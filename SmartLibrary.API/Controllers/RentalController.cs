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
    public class RentalController : ControllerBase
    {

        private readonly IRepository repository;
        private readonly IMapper mapper;

        public RentalController(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpGet]
        
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var result = await this.repository.GetAllRentalsAsync(pageParams);
            var rentalResult = this.mapper.Map<IEnumerable<RentalDto>>(result);
            Response.AddPagination(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
            return Ok(this.mapper.Map<IEnumerable<RentalDto>>(result));
        }

        //// GET api/<RentalController>/5
        [HttpGet("{id}")]
        
        public IActionResult GetById(int id)
        {
            var rental = this.repository.GetRental(id);
            if(rental == null) return BadRequest("Rental not found");
            var rentalDto = this.mapper.Map<RentalDto>(rental);
            return Ok(rentalDto);
        }

        // POST api/<RentalController>
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public IActionResult Post(RentalRegisterDto model)
        {
            var rental = this.mapper.Map<Rental>(model);

            this.repository.Add(rental);
            if (this.repository.SaveChanges())
            {
                return Created($"/api/rental/{model.Id}", this.mapper.Map<RentalDto>(rental));
            }
            return BadRequest("Rental not found");
        }

        // PUT api/<RentalController>/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public IActionResult Put(int id, RentalRegisterDto model)
        {
            var rental = this.repository.GetRental(id);
            if (rental == null) return BadRequest("Rental not found");

            this.mapper.Map(model, rental);
            this.repository.Update(rental);
            if (this.repository.SaveChanges())
            {
                return Created($"/api/rental/{model.Id}", this.mapper.Map<RentalDto>(rental));
            }
            return BadRequest("Rental not found");
        }
        // PATCH api/<RentalController>/5
        [HttpPatch("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public IActionResult Patch(int id, RentalRegisterDto model)
        {
            var rental = this.repository.GetRental(id);
            if (rental == null) return BadRequest("Rental not found");

            this.mapper.Map(model, rental);
            this.repository.Update(rental);
            if (this.repository.SaveChanges())
            {
                return Created($"/api/rental/{model.Id}", this.mapper.Map<RentalDto>(rental));
            }
            return BadRequest("Rental not found");
        }

        // DELETE api/<RentalController>/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]

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
