using Hotel.Rates.Data;
using Hotel.Rates.Data.Enum;
using Hotel.Rates.Data.Plans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Rates.Infraestructure.Configurations
{
    public class RatePlanConfiguration : IEntityTypeConfiguration<RatePlan>
    {
        public void Configure(EntityTypeBuilder<RatePlan> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.HasDiscriminator<int>("RatePlanType")
                .HasValue<NightlyRatePlan>((int)RatePlanType.Nightly)
                .HasValue<IntervalRatePlan>((int)RatePlanType.Interval);

            builder.HasMany(r => r.Seasons)
                .WithOne(s => s.RatePlan)
                .HasForeignKey(s => s.RatePlanId);
        }
    }
}
