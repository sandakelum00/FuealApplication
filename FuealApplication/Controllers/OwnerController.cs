using BCrypt.Net;
using FuealApplication.Models;
using FuealApplication.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver.Core.Authentication;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FuealApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        //public static OwnerDto newOwner = new OwnerDto();
        private readonly IOwnerServices ownerServices;

        public OwnerController(IOwnerServices ownerServices) 
        {
            this.ownerServices = ownerServices;
        }
        // GET: api/<OwnerController>
        [HttpGet]
        public ActionResult<List<Owner>>Get()
        {
            return ownerServices.GetOwners();
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public ActionResult<Owner>Get(string id)
        {
            var owner = ownerServices.GetOwner(id);

            if (owner == null)
            {
                return NotFound("Owner not found");
            }
            return owner;
        }

        // POST api/<OwnerController>
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            ownerServices.CreateOwner(owner);

            return CreatedAtAction(nameof(Get), new { id = owner.Id }, owner);
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Owner owner)
        {
            var existingOwner= ownerServices.GetOwner(id);

            if (existingOwner == null)
            {
                return NotFound($"Not found");
            }

            ownerServices.UpdateOwner(id,owner);

            return NoContent();
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var owner = ownerServices.GetOwner(id);

            if (owner == null)
            {
                return NotFound($"Not found");
            }

            ownerServices.RemoveOwner(owner.Id);

            return Ok($"Deleted {id} successfully!");
        }

        [HttpPost("login")]
        public ActionResult<Owner> Post(string username, string password)
        {
            var ownerUsername = ownerServices.AuthenticateUsername(username).ToString();
            var ownerPassword = ownerServices.AuthenticatePassword(password).ToString();

            if ( username == null || password == null)
            {
                return BadRequest("Provide user credentials");
            }

            if (ownerUsername == null || ownerPassword == null)
            {
                return BadRequest("Incorrect User credentials");
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, ownerPassword);

            if (isValidPassword)
            return Ok("User logged in successfully");

            return BadRequest();

        }

    }
}
