using FuealApplication.Models;
using FuealApplication.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FuealApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices userServices;

        public UserController(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return userServices.GetUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            var user = userServices.GetUser(id);

            if (user == null)
            {
                return NotFound($"User not found");
            }
            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            userServices.CreateUser(user);

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] User user)
        {
            var existingUser = userServices.GetUser(id);

            if (existingUser == null)
            {
                return NotFound($"Not found");
            }

            userServices.UpdateUser(id, user);

            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var user = userServices.GetUser(id);

            if (user == null)
            {
                return NotFound($"Not found");
            }

            userServices.RemoveUser(user.Id);

            return Ok($"Deleted {id} successfully!");
        }
    }
}
