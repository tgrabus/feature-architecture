using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DbContexts;
using Models.Entities.AppContext;

namespace DataAccess.Queries
{
    public class GetAddressesByPersonIdQuery : Query
    {
        public int PersonId { get; set; }

        internal override QueryResult Execute(IAppContext context)
        {
            AssertThatArgumentIsValid(context);

            var dbset = context.Set<Address>();

            var addresses = dbset.Where(
                address => address.OccupantId == PersonId).ToList();

            return new GetAddressesByPersonIdQueryResult()
            {
                Addresses = addresses,
                PersonId = PersonId
            };
        }

        internal override async Task<QueryResult> ExecuteAsync(IAppContext context)
        {
            AssertThatArgumentIsValid(context);

            var addresses = await context.Set<Address>().Where(
                address => address.OccupantId == PersonId).ToListAsync();

            return new GetAddressesByPersonIdQueryResult()
            {
                Addresses = addresses,
                PersonId = PersonId
            };
        }
    }

    public class GetAddressesByPersonIdQueryResult : QueryResult
    {
        public int PersonId { get; set; }

        public IEnumerable<Address> Addresses { get; set; }
    }
}