using Hotel.Rates.Data;
using Hotel.Rates.Data.Entities;
using Hotel.Rates.Data.Enum;
using Hotel.Rates.Infraestructure.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Rates.Tests.Context
{
    public static class DbContextUtils
    {
        public static InventoryContext GetInMemoryContext()
        {
            var connection = new SqliteConnection("DataSource=:memory");
            connection.Open();
            var dbContextOptions = new DbContextOptionsBuilder<InventoryContext>()
                .UseSqlite(connection)
                .Options;

            var context = new InventoryContext(dbContextOptions);
            context.Database.EnsureCreated();
            return context;
        }

        public static void SeedRooms(this InventoryContext context)
        {
            context.Add(new Room
            {
                Amount = 2,
                Id = -2,
                MaxAdults = 1,
                MaxChildren = 0,
                Name = "Room 1"
            });
            context.Add(new Room
            {
                Amount = 22,
                Id = -1,
                MaxAdults = 12,
                MaxChildren = 20,
                Name = "Room 12"
            });
        }

        public static void SeedRatePlans(this InventoryContext context)
        {
            context.Add(new RatePlanRoom
            {
                Room = new Room
                {
                    Name = "Room 1",
                    Amount = 200,
                },
                RatePlanId = 20,
                
            });
        }

    }
}