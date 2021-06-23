using System;
using System.Collections.Generic;
using System.Linq;
using Hotel.Rates.Data.Entities;
using Hotel.Rates.Infraestructure.Context;

namespace Hotel.Rates.Infraestructure.Repositories
{
    public class RoomRepository : BaseRepository<Room>
    {
        private readonly InventoryContext _inventoryContext;

        public RoomRepository(InventoryContext inventoryContext) : base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }

        public override IReadOnlyList<Room> Get()
        {
            return _inventoryContext.Rooms.ToList();
        }

        public override Room Getid(int id)
        {
            return _inventoryContext.Rooms.FirstOrDefault(x => x.Id == id);
        }

        public override IReadOnlyList<Room> Filter(Func<Room, bool> predicate)
        {
            return _inventoryContext.Rooms.Where(predicate).ToList();
        }
    }
}