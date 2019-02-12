using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreProject.Entities;
using NetCoreProject.Interfaces;

namespace NetCoreProject.Repositories
{
    public class CityRepository :ICityInfoRepository
    {
        private CityInfoContext _context;
        public CityRepository(CityInfoContext context)
        {
            _context = context;
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(c => c.Name).ToList();
        }

        public City GetCity(int cityId, bool includePOI)
        {
            return _context.Cities.Include(c => c.PointsOfInterest).FirstOrDefault(c => c.Id == cityId);
        }

        public IEnumerable<PointOfInterest> GetPointOfInterests(int cityId)
        {
            return _context.PointOfInterests.Where(p => p.City.Id == cityId).ToList();
        }

        public IEnumerable<PointOfInterest> GetPointOfInterests()
        {
            return _context.PointOfInterests.OrderBy(c => c.Name).ToList();
        }
    }
}
