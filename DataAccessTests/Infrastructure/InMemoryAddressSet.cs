using System;
using System.Collections.Generic;
using System.Linq;
using Models.Entities.AppContext;

namespace DataAccessTests.Infrastructure
{
    public class InMemoryAddressSet : InMemoryDbSet<Address>
    {
        public InMemoryAddressSet()
        {
        }

        public InMemoryAddressSet(IEnumerable<Address> entities) : base(entities)
        {
        }

        public override Address Find(params object[] keyValues)
        {
            return Set.FirstOrDefault(x => x.Id == (int) keyValues[0]);
        }

        public static InMemoryAddressSet Build()
        {
            var set = new List<Address>();
            var random = new Random();

            for (int i = 1; i <= 50; i++)
            {
                set.Add(new Address()
                {
                    Id = i,
                    OccupantId = random.Next(1, 10),
                    Street = "Street_" + i,
                    City = "City_" + i,
                    FlatNumber = "FlatNumber_" + i,
                    HouseNumber = "HouseNumber_" + i
                });
            }

            return new InMemoryAddressSet(set);
        }
    }
}