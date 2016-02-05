using System.Threading.Tasks;
using DataAccess.DbContexts;

namespace DataAccess.Queries
{
    public class GetEntityByIdQuery<TEntity> : Query where TEntity : class
    {
        public int Id { get; set; }

        internal override QueryResult Execute(IAppContext context)
        {
            var entity = context.Set<TEntity>().Find(Id);

            return new GetEntityByIdQueryResult<TEntity>()
            {
                Entity = entity
            };
        }

        internal override async Task<QueryResult> ExecuteAsync(IAppContext context)
        {
            var entity = await Task.Run(() => context.Set<TEntity>().Find(Id));

            return new GetEntityByIdQueryResult<TEntity>()
            {
                Entity = entity
            };
        }
    }

    public class GetEntityByIdQueryResult<TEntity> : QueryResult where TEntity: class
    {
        public TEntity Entity { get; set; }
    }
}