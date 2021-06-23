using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialApp.Core.Interfaces
{
    public interface IRepository<TEntity>
    {
        IReadOnlyList<TEntity> Get();
        TEntity Getid(int id);
        TEntity Create(TEntity entity);
        IReadOnlyList<TEntity> Filter(Func<TEntity, bool> predicate);
    }
}
