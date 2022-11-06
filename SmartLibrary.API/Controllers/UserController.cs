using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartLibrary.API.Data;
using SmartLibrary.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IRepository repository;
        public UserController(IRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.repository.GetAllUsers();
            return Ok(result);
        }

        //// GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = this.repository.GetUser(id);
            if(user == null) return BadRequest("User not found");
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post(User user)
        {
            this.repository.Add(user);
            if (this.repository.SaveChanges())
            {
                return Ok(user);
            }
            return BadRequest("User not found");
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Post(int id, User user)
        {
            var us = this.repository.GetUser(id);
            if (us == null) return BadRequest("User not found");

            this.repository.Update(user);
            if (this.repository.SaveChanges())
            {
                return Ok(user);
            }
            return BadRequest("User not found");
        }
        // PATCH api/<UserController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, User user)
        {
            var us = this.repository.GetUser(id);
            if (us == null) return BadRequest("User not found");

            this.repository.Update(user);
            if (this.repository.SaveChanges())
            {
                return Ok(user);
            }
            return BadRequest("User not found");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var us = this.repository.GetUser(id);
            if (us == null) return BadRequest("User not found");

            this.repository.Delete(us);
            if (this.repository.SaveChanges())
            {
                return Ok("User deleted");
            }
            return BadRequest("User not found");
        }
    }
}
