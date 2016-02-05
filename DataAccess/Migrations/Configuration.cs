using Models.Entities.AppContext;

namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Implementation.DbContexts.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.Implementation.DbContexts.AppContext context)
        {
            context.Persons.AddOrUpdate(person => new { person.FirstName, person.LastName }, new []
            {
                new Person()
                {
                    FirstName = "Jan",
                    LastName = "Dworzec",
                    Addresses = new []
                    {
                        new Address()
                        {
                            Id = 1,
                            City = "Warszawa",
                            FlatNumber = "1",
                            HouseNumber = "2",
                            Street = "Dominikañska"
                        },
                        new Address()
                        {
                            Id = 2,
                            City = "Warszawa",
                            FlatNumber = "5",
                            HouseNumber = "22",
                            Street = "W³adys³awa"
                        }
                    }
                },
                new Person()
                {
                    FirstName = "Krzysztof",
                    LastName = "Kielich",
                    Addresses = new []
                    {
                        new Address()
                        {
                            Id = 3,
                            City = "Gdañsk",
                            FlatNumber = "77",
                            HouseNumber = "13",
                            Street = "Grunwaldzka"
                        }
                    }
                },
                new Person()
                {
                    FirstName = "Marian",
                    LastName = "Pi³a",
                    Addresses = new []
                    {
                        new Address()
                        {
                            Id = 4,
                            City = "Sopot",
                            FlatNumber = "4",
                            HouseNumber = "103",
                            Street = "Armi Krajowej"
                        }
                    }
                }
            });
        }
    }
}
