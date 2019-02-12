using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreProject.Model;

namespace NetCoreProject
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; }

        public CitiesDataStore()
        {
            this.Cities = new List<CityDto>()
                {
                    new CityDto()
                    {
                        Id = 1,
                        Name = "New York",
                        Description = "This one never sleeps.",
                        PointsOfInterest = new List<PointOfInterestDto>()
                        {
                            new PointOfInterestDto()
                            {
                                Name = "Test1",
                                Description = "Test2",
                                Id = 1
                            },
                            new PointOfInterestDto()
                            {
                                Name = "Test2",
                                Description = "Test3",
                                Id = 2
                            }
                        }

                    },
                    new CityDto()
                    {
                        Id = 2,
                        Name = "Antwerp",
                        Description = "This one has a big cathedral."
                    },
                    new CityDto()
                    {
                        Id = 3,
                        Name = "Malta",
                        Description = "This one is small."
                    },
                };
        }
    }
}
