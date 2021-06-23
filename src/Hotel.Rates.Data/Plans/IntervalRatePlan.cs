using Hotel.Rates.Data.Enum;

namespace Hotel.Rates.Data.Plans
{
    public class IntervalRatePlan : RatePlan
    {
        public IntervalRatePlan()
        {
            RatePlanType = (int) Enum.RatePlanType.Interval;
        }

        public int IntervalLength { get; set; }
    }
}
