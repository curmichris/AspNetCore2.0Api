using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreProject.Model;

namespace NetCoreProject.Controllers
{
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {
        private readonly ILogger<PointsOfInterestController> _logger;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            try
            {
                var city = new CitiesDataStore().Cities.FirstOrDefault(c => c.Id == cityId);

                if (city == null)
                {
                    _logger.LogInformation($"City was not found for id {cityId}");
                    return NotFound();
                }

                return Ok(city.PointsOfInterest);
            }
            catch (Exception e)
            {
                _logger.LogCritical($"Exception while getting POI");
                return StatusCode(500);
            }
        }

        [HttpGet("{cityId}/pointsofinterest/{id}")]
        public IActionResult GetPointsOfInterest(int cityId, int id)
        {
            var city = new CitiesDataStore().Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var poi = city.PointsOfInterest.FirstOrDefault(x => x.Id == id);
            if (poi == null)
            {
                return NotFound();
            }

            return Ok(poi);
        }

        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId,
            [FromBody] POIForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var city = new CitiesDataStore().Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = new CitiesDataStore().Cities.SelectMany(
                c => c.PointsOfInterest).Max(p => p.Id);

            var createdPoi = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Description = pointOfInterest.Description,
                Name = pointOfInterest.Name
            };
            city.PointsOfInterest.Add(createdPoi);

            return CreatedAtRoute("{cityId}/pointsofinterest/{id}", new
            {
                cityId = cityId,
                id = ++maxPointOfInterestId
            }, createdPoi);

        }

        [HttpPatch("{cityId}/pointsofinterest/{id}")]
        public IActionResult Patch(int cityId, int id,
            [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var city = new CitiesDataStore().Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == id);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            var poiToPatch = new PointOfInterestForUpdateDto()
            {
                Name = pointOfInterestFromStore.Name,
                Decription = pointOfInterestFromStore.Description

            };

            patchDoc.ApplyTo(poiToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest((ModelState));
            }

            pointOfInterestFromStore.Name = poiToPatch.Name;
            pointOfInterestFromStore.Description = poiToPatch.Decription;

            return NoContent();
        }
    }
}
