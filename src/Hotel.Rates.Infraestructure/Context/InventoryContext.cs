using Hotel.Rates.Data;
using Hotel.Rates.Data.Configurations;
using Hotel.Rates.Data.Entities;
using Hotel.Rates.Data.Plans;
using Hotel.Rates.Infraestructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Rates.Infraestructure.Context
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Season> Seasons { get; set; }

        public DbSet<RatePlan> RatePlans { get; set; }

        public DbSet<NightlyRatePlan> NightlyRatePlans { get; set; }

        public DbSet<IntervalRatePlan> IntervalRatePlans { get; set; }

        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RatePlanConfiguration());
            modelBuilder.ApplyConfiguration(new NightlyRatePlanConfiguration());
            modelBuilder.ApplyConfiguration(new IntervalRatePlanConfiguration());
            modelBuilder.ApplyConfiguration(new SeasonConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new RatePlanRoomConfiguration());
        }
    }
}
