using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController(ITripService tripService) : ControllerBase
    {
        private readonly ITripService _tripService=tripService;
      

        [HttpGet]
        [Route("GetAllTrips")]

        public IActionResult GetAllTrips()
        {
            var result = _tripService.GetAll();
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{Id}")]

        public IActionResult GetTrip(int id)
        {
            var result = _tripService.Get(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpPost]
        public IActionResult AddTrip(Trip trip)
        {
            var result = _tripService.Add(trip);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPut]

        public IActionResult UpdateTrip(Trip trip) 
        {
            var result = _tripService.Update(trip);
            if(result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteTrip(int id)
        {
            var trip = _tripService.Get(id).Data;
            if (trip == null)
            {
                return NotFound("Trip not found.");
            }

            var result = _tripService.Delete(trip);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }
    }
    
}
