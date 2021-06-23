using System;
using System.Collections.Generic;

namespace Hotel.Rates.Data.Interfaces
{
    public interface IRepository<TEntity>
    {
        IReadOnlyList<TEntity> Get();
        TEntity Getid(int id);
        TEntity Create(TEntity entity);
        void Decreace(TEntity entity);
        IReadOnlyList<TEntity> Filter(Func<TEntity, bool> predicate);
    }
}
