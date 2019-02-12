using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreProject.Model;

namespace NetCoreProject.CityDto
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPointsOfInterest => PointsOfInterest.Count;

        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; }
            = new List<PointOfInterestDto>();
    }
}
