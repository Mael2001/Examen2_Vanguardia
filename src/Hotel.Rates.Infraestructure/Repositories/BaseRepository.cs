using System;
using System.Collections.Generic;
using FinancialApp.Core.Interfaces;
using Hotel.Rates.Infraestructure.Context;

namespace FinancialApp.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
    {
        private readonly InventoryContext _inventoryContext;
        public BaseRepository(InventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }

        public abstract IReadOnlyList<TEntity> Get();
        public abstract TEntity Getid(int id);

        public TEntity Create(TEntity entity)
        {
            _inventoryContext.AddAsync(entity);
            _inventoryContext.SaveChangesAsync();
            return entity;
        }

        public abstract IReadOnlyList<TEntity> Filter(Func<TEntity, bool> predicate);
    }
}