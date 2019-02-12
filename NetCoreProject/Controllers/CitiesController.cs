using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreProject.Interfaces;
using NetCoreProject.Model;

namespace NetCoreProject.Controllers
{
    [Route("/api/cities")]
    public class CitiesController : Controller
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var cityEntities = _cityInfoRepository.GetCities();
            var results = cityEntities.Select(o => new CityWithoutPointsOfInterestDto()
            {
                Name = o.Name,
                Description = o.Description,
                Id = o.Id
            });

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var city = _cityInfoRepository.GetCity(id, false);

            var result = new CityWithoutPointsOfInterestDto()
            {
                Name = city.Name,
                Description = city.Description,
                Id = city.Id
            };

            return Ok(result);
        }
    }
}