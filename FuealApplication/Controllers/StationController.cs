using FuealApplication.Models;
using FuealApplication.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Operations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FuealApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationServices stationServices;

        public StationController(IStationServices stationServices)
        {
            this.stationServices = stationServices;
        }

        // GET: api/<StationController>
        [HttpGet]
        public ActionResult<List<Station>> Get()
        {
            return stationServices.GetStations();
        }

        // GET api/<StationController>/5
        [HttpGet("{id}")]
        public ActionResult<Station> Get(string id)
        {
            var station = stationServices.GetStation(id);

            if (station == null) 
            {
                return NotFound($"Station not found");
            }
            return station;
        }

        // POST api/<StationController>
        [HttpPost]
        public ActionResult<Station> Post([FromBody] Station station)
        {
            stationServices.CreateStation(station);

            return CreatedAtAction(nameof(Get), new { id = station.Id }, station);
        }

        // PUT api/<StationController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Station station)
        {
            var existingStation = stationServices.GetStation(id);

            if (existingStation == null)
            {
                return NotFound($"Not found");
            }

            stationServices.UpdateStation(id, station);

            return NoContent();
        }

        // DELETE api/<StationController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var station = stationServices.GetStation(id);

            if (station == null)
            {
                return NotFound($"Not found");
            }

            stationServices.RemoveStation(station.Id);

            return Ok($"Deleted {id} successfully!");
            }
    }
}
