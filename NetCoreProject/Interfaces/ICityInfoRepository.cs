using System.Collections.Generic;
using System.Linq;
using NetCoreProject.Entities;

namespace NetCoreProject.Interfaces
{
    public interface ICityInfoRepository
    {
        IEnumerable<City> GetCities();
        City GetCity(int cityId, bool includePOI);
        IEnumerable<PointOfInterest> GetPointOfInterests(int cityId);
        IEnumerable<PointOfInterest> GetPointOfInterests();
    }
}
