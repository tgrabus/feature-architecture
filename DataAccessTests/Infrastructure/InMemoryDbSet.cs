using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessTests.Infrastructure
{
    public class InMemoryDbSet<TEntity> : IDbSet<TEntity> where TEntity : class
    {
        protected readonly HashSet<TEntity> Set;
        readonly IQueryable<TEntity> queryableSet;

        public InMemoryDbSet()
            : this(Enumerable.Empty<TEntity>())
        {
        }

        public InMemoryDbSet(IEnumerable<TEntity> entities)
        {
            Set = new HashSet<TEntity>();
            foreach (var entity in entities)
            {
                Set.Add(entity);
            }
            queryableSet = Set.AsQueryable();
        }

        public TEntity Add(TEntity entity)
        {
            Set.Add(entity);
            return entity;
        }

        public TEntity Attach(TEntity entity)
        {
            Set.Add(entity);
            return entity;
        }

        public TEntity Remove(TEntity entity)
        {
            Set.Remove(entity);
            return entity;
        }

        public virtual TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, TEntity
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public virtual TEntity Create()
        {
            return Activator.CreateInstance<TEntity>();
        }

        public virtual TEntity Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<TEntity> Local => new ObservableCollection<TEntity>(queryableSet);

        public IEnumerator<TEntity> GetEnumerator()
        {
            return queryableSet.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return queryableSet.GetEnumerator();
        }

        public Type ElementType => queryableSet.ElementType;

        public Expression Expression => queryableSet.Expression;

        public IQueryProvider Provider => queryableSet.Provider;
    }
}