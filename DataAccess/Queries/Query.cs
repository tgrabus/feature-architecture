using System;
using System.Threading.Tasks;
using DataAccess.DbContexts;

namespace DataAccess.Queries
{
    public abstract class Query
    {
        internal virtual QueryResult Execute(IAppContext context)
        {
            throw new NotImplementedException();
        }

        internal virtual Task<QueryResult> ExecuteAsync(IAppContext context)
        {
            throw new NotImplementedException();
        }

        protected internal virtual void AssertThatArgumentIsValid(IAppContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
        }
    }

    public abstract class QueryResult
    {
    }
}