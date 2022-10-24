using FuealApplication.Models;
using FuealApplication.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FuealApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
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
                return NotFound($"Station not found");
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
    
    }
}
