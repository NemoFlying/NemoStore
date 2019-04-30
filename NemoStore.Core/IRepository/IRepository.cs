using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NemoStore.Core.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);


        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> whereLambda);

    }
}
