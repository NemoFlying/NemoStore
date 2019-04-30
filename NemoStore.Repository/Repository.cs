using NemoStore.Core.IRepository;
using NemoStore.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NemoStore.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected NemoStoreDbContext _dbContext;
        
        public Repository(NemoStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> whereLambda)
        {
            return _dbContext.Set<TEntity>().Where(whereLambda);
        }
    }
}
