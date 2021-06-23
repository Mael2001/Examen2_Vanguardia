using System;
using System.Collections.Generic;
using System.Linq;
using FinancialApp.Data.Repositories;
using Hotel.Rates.Data;
using Hotel.Rates.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Rates.Infraestructure.Repositories
{
    public class RatePlanRepository: BaseRepository<RatePlan>
    {
        private readonly InventoryContext _inventoryContext;

        public RatePlanRepository(InventoryContext inventoryContext) : base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }

        public override IReadOnlyList<RatePlan> Get()
        {
            return _inventoryContext.RatePlans.ToList();
        }
        public override RatePlan Getid(int id)
        {
            var ratePlan = _inventoryContext.RatePlans
                .Include(r => r.Seasons)
                .Include(r => r.RatePlanRooms)
                .ThenInclude(r => r.Room)
                .FirstOrDefault(x => x.Id == id);
            return ratePlan;
        }

        public override IReadOnlyList<RatePlan> Filter(Func<RatePlan, bool> predicate)
        {
            return _inventoryContext.RatePlans.Where(predicate).ToList();
        }
    }
}