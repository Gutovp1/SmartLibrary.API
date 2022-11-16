using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartLibrary.API.Data;
using SmartLibrary.API.Helper;
using SmartLibrary.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {

        private readonly IRepository repository;
        public PublisherController( IRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var result = await this.repository.GetAllPublishersAsync(pageParams);
            Response.AddPagination(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
            return Ok(result);
        }

        //// GET api/<PublisherController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var publisher = this.repository.GetPublisher(id);
            if(publisher == null) return BadRequest("Publisher not found");
            return Ok(publisher);
        }

        // POST api/<PublisherController>
        [HttpPost]
        public IActionResult Post(Publisher publisher)
        {
            this.repository.Add(publisher);
            if (this.repository.SaveChanges())
            {
                return Ok(publisher);
            }
            return BadRequest("Publisher not found");
        }

        // PUT api/<PublisherController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Publisher publisher)
        {
            var rent = this.repository.GetPublisher(id);
            if (rent == null) return BadRequest("Publisher not found");

            this.repository.Update(publisher);
            if (this.repository.SaveChanges())
            {
                return Ok(publisher);
            }
            return BadRequest("Publisher not found");
        }
        // PATCH api/<PublisherController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Publisher publisher)
        {
            var rent = this.repository.GetPublisher(id);
            if (rent == null) return BadRequest("Publisher not found");

            this.repository.Update(publisher);
            if (this.repository.SaveChanges())
            {
                return Ok(publisher);
            }
            return BadRequest("Publisher not found");
        }

        // DELETE api/<PublisherController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var rent = this.repository.GetPublisher(id);
            if (rent == null) return BadRequest("Publisher not found");

            this.repository.Delete(rent);
            if (this.repository.SaveChanges())
            {
                return Ok("Publisher deleted");
            }
            return BadRequest("Publisher not found");
        }
    }
}
