using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkMyBike.Data;
using ParkMyBike.Data.Entities;
using ParkMyBike.Models;

namespace ParkMyBike.Controllers
{
    [ApiController]
    public class BikeRacksController : Controller
    {
        private readonly IBikeRackRepository _repository;
        private readonly ILogger<BikeRackRepository> _logger;

        public BikeRacksController(IBikeRackRepository repository, ILogger<BikeRackRepository> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/[Controller]")]
        public ActionResult<IEnumerable<BikeRack>> GetAll()
        {
            try
            {
                return Ok(_repository.GetAllBikeRacks());
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get bike racks: {e.Message}");
                return BadRequest("Request to database failed. Check the logger for specifics.");
            }
        }

        [HttpGet]
        [Route("api/[Controller]/{id}")]
        public ActionResult<BikeRack> Get(int id)
        {
            try
            {
                return Ok(_repository.ViewSingleBikeRack(id));
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to view bike rack with ID {id}: {e.Message}");
                return BadRequest("Request to database failed. Check the logger for specifics.");
            }
        }

        [HttpPost]
        [Route("api/[Controller]")]
        public ActionResult<BikeRack> Post([FromBody]BikeRack rack)
        {
            try
            {
               return Ok(_repository.AddBikeRack(rack));
            }
            catch (Exception e) 
            {
                _logger.LogError($"Failed to create bike rack {rack}: {e.Message}");
                return BadRequest("Request to database failed. Check the logger for specifics.");
            }
        }

        [HttpPut]
        [Route("api/[Controller]")]
        public ActionResult<BikeRack> Put([FromForm]int rackId, [FromForm]int newNumberOfRacks)
        {
            try
            {
                return Ok(_repository.UpdateNumberofRacksOnBikeRack(rackId, newNumberOfRacks));
            }
            catch(Exception e)
            {
                _logger.LogError($"Failed to update bike rack with id {rackId}: {e.Message}");
                return BadRequest("Request to database failed. Check the logger for specifics.");
            }
        }

        [HttpDelete]
        [Route("api/[Controller]/delete/{id}")]
        public ActionResult<BikeRack> Delete([FromBody]BikeRack rack)
        {
            try
            {
                return Ok(_repository.DeleteBikeRack(rack));
            }
            catch(Exception e)
            {
                _logger.LogError($"Failed to delete bike rack {rack}: {e.Message}");
                return BadRequest("Request to database failed. Check the logger for specifics.");
            }
        }
    }
}
