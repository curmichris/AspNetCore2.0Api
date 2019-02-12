using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreProject.Entities;

namespace NetCoreProject.Extensions
{
    public static class CityInfoContextExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }

            var cities = new List<City>()
            {
                new City()
                {
                    Name = "New York",
                    Description = "This one never sleeps.",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Central Park",
                            Description = "Central Park Desc",
                        },
                        new PointOfInterest()
                        {
                            Name = "Empire State Building",
                            Description = "ESB Building Desc",
                        }
                    }

                },
                new City()
                {
                    Name = "Antwerp",
                    Description = "This one has a big cathedral."
                },
                new City()
                {
                    Name = "Malta",
                    Description = "This one is small."
                },
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
