using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ParkMyBike.Models;
using ParkMyBike.Models.Entities;
using ParkMyBike.ViewModels;

namespace ParkMyBike.Controllers
{
    [ApiController]
    public class BikeRacksController : Controller
    {
        private readonly IBikeRackRepository _repository;
        private readonly ILogger<BikeRackRepository> _logger;
        private readonly IMapper _mapper;

        public BikeRacksController(IBikeRackRepository repository, ILogger<BikeRackRepository> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/[Controller]")]
        public ActionResult<IEnumerable<BikeRack>> GetAll()
        {
            var bikeRacks = _mapper.Map<IEnumerable<BikeRack>, IEnumerable<BikeRackViewModel>>(_repository.GetAllBikeRacks());
            var bikeRacksJson = JsonConvert.SerializeObject(bikeRacks);

            try
            {
                return Ok(bikeRacksJson);
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
                var rack = _repository.ViewSingleBikeRack(id);
                if (rack != null)
                {
                    return Ok(_mapper.Map<BikeRack, BikeRackViewModel>(rack));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to view bike rack with ID {id}: {e.Message}");
                return BadRequest("Request to database failed. Check the logger for specifics.");
            }
        }

        [HttpPost]
        [Route("api/[Controller]")]
        public ActionResult<BikeRack> Post([FromBody]BikeRackViewModel rack)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newRack = _mapper.Map<BikeRackViewModel, BikeRack>(rack);
                    _repository.AddBikeRack(newRack);
                    return Created($"/api/[Controller]/{newRack.Id}", _mapper.Map<BikeRack, BikeRackViewModel>(newRack));
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to create bike rack {rack}: {e.Message}");
                return BadRequest("Request to database failed. Check the logger for specifics.");
            }
        }

        [HttpPut]
        [Route("api/[Controller]/{id}")]
        public ActionResult<BikeRack> UpdateBikeRack([FromBody]BikeRackViewModel rack)
        {
            try
            {
                var rackToBeUpdated = _mapper.Map<BikeRackViewModel, BikeRack>(rack);
                return Ok(_repository.UpdateBikeRack(rackToBeUpdated));
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to update bike rack with id {rack.RackId}: {e.Message}");
                return BadRequest("Request to database failed. Check the logger for specifics.");
            }
        }

        [HttpDelete]
        [Route("api/[Controller]/{id}")]
        public ActionResult<BikeRack> Delete(int id)
        {
            try
            {
                var rack = _repository.ViewSingleBikeRack(id);
                if (rack != null)
                {
                    return Ok(_repository.DeleteBikeRack(rack));
                }
                else
                {
                    return BadRequest("No rack has been selected for deletion.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to delete bike rack {id}: {e.Message}");
                return BadRequest("Request to database failed. Check the logger for specifics.");
            }
        }
    }
}
