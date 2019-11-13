﻿using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkMyBike.Models;
using ParkMyBike.Resources.Enums;
using ParkMyBike.ViewModels;

namespace ParkMyBike.Controllers
{
    [ApiController]
    public class BikeRacksController : Controller
    {
        private readonly IBikeRackRepository _repository;
        private readonly ILogger<BikeRackRepository> _logger;
        private IMapper _mapper;

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
            try
            {
                return Ok(_mapper.Map<IEnumerable<BikeRack>, IEnumerable<BikeRackViewModel>>(_repository.GetAllBikeRacks()));
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
        [Route("api/[Controller]/{id}/numberOfRacks={newNumberOfRacks}")]
        public ActionResult<BikeRack> UpdateNumberOfRacks([FromForm]int id, [FromForm]int newNumberOfRacks)
        {
            try
            {
                return Ok(_repository.UpdateNumberofRacksOnBikeRack(id, newNumberOfRacks));
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to update bike rack with id {id}: {e.Message}");
                return BadRequest("Request to database failed. Check the logger for specifics.");
            }
        }

        [HttpPut]
        [Route("api/[Controller]/{id}/description={newDescription}")]
        public ActionResult<BikeRack> UpdateLocationDescription([FromForm]int id, [FromForm]string newDescription)
        {
            try
            {
                return Ok(_repository.UpdateBikeRackLocationDescription(id, newDescription));
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to update bike rack with id {id}: {e.Message}");
                return BadRequest("Request to database failed. Check the logger for specifics.");
            }
        }

        [HttpPut]
        [Route("api/[Controller]/{id}/status={newStatus}")]
        public ActionResult<BikeRack> UpdateRackStatus([FromForm]int id, [FromForm]RackStatus newStatus)
        {
            try
            {
                return Ok(_repository.UpdateBikeRackStatus(id, newStatus));
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to update bike rack with id {id}: {e.Message}");
                return BadRequest("Request to database failed. Check the logger for specifics.");
            }
        }

        [HttpPut]
        [Route("api/[Controller]/{id}/type={newType}")]
        public ActionResult<BikeRack> UpdateRackType([FromForm]int id, [FromForm]RackType newType)
        {
            try
            {
                return Ok(_repository.UpdateBikeRackType(id, newType));
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to update bike rack with id {id}: {e.Message}");
                return BadRequest("Request to database failed. Check the logger for specifics.");
            }
        }

        [HttpDelete]
        [Route("api/[Controller]/delete/{id}")]
        public ActionResult<BikeRack> Delete([FromBody]BikeRackViewModel rack)
        {
            try
            {
                BikeRack rackToDelete = _mapper.Map<BikeRackViewModel, BikeRack>(rack);
                if (rackToDelete != null)
                {
                    return Ok(_repository.DeleteBikeRack(rackToDelete));
                }
                else
                {
                    return BadRequest("No rack has been selected for deletion.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to delete bike rack {rack}: {e.Message}");
                return BadRequest("Request to database failed. Check the logger for specifics.");
            }
        }
    }
}
