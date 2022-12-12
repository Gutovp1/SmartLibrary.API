using Microsoft.AspNetCore.Authorization;
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
    public class UserController : ControllerBase
    {

        private readonly IRepository repository;

        public UserController(IRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var result = await this.repository.GetAllUsersAsync(pageParams);
            return Ok(result);
        }

        //// GET api/<UserController>/5
        [HttpGet("{id}")]
        
        public IActionResult GetById(int id)
        {
            var user = this.repository.GetUser(id);
            if(user == null) return BadRequest("User has not been found.");
            return Ok(user);
        }

        //// GET api/<UserController>/teste@teste.com
        [HttpGet("{email}")]

        public IActionResult GetByEmail(string email)
        {
            var user = this.repository.GetUserEmail(email);
            if (user == null) return BadRequest("User has not been found.");
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public IActionResult Post(User user)
        {
            var us = this.repository.GetUserEmail(user.Email);
            if (us != null) return BadRequest("This e-mail is already registered. Try a different email.");

            this.repository.Add(user);
            if (this.repository.SaveChanges())
            {
                return Ok(user);
            }
            return BadRequest("User has not been found.");
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public IActionResult Put(int id, User user)
        {
            var us = this.repository.GetUser(id);
            if (us == null) return BadRequest("User has not been found.");
            
            us = this.repository.GetUserEmail(user.Email);
            if(us != null) return BadRequest("This e-mail is already registered. Try a different email.");

            this.repository.Update(user);
            if (this.repository.SaveChanges())
            {
                return Ok(user);
            }
            return BadRequest("User has not been found.");
        }
        // PATCH api/<UserController>/5
        [HttpPatch("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public IActionResult Patch(int id, User user)
        {
            var us = this.repository.GetUser(id);
            if (us == null) return BadRequest("User has not been found.");

            this.repository.Update(user);
            if (this.repository.SaveChanges())
            {
                return Ok(user);
            }
            return BadRequest("User has not been found.");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public IActionResult Delete(int id)
        {
            var us = this.repository.GetUser(id);
            if (us == null) return BadRequest("User has not been found.");

            if (this.repository.IsUserRenting(us)) return BadRequest("User has not been deleted due to related pending rentals.");

            this.repository.Delete(us);
            if (this.repository.SaveChanges())
            {
                return Ok("User has been deleted successfully.");
            }
            return BadRequest("User has not been found.");
        }
    }
}
