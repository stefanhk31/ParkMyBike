using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkMyBike.Data;
using ParkMyBike.Data.Entities;

namespace ParkMyBike.Controllers
{
    [Route("api/[Controller]")]
    public class BikeRacksController : Controller
    {
        private readonly IBikeRackRepository _repository;
        
        public BikeRacksController(IBikeRackRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<BikeRack> Get()
        {
            return _repository.GetAllBikeRacks();
        }

    }
}
