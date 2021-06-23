namespace Hotel.Rates.Data.Plans
{
    public class NightlyRatePlan : RatePlan
    {
        public NightlyRatePlan()
        {
            RatePlanType = (int)Enum.RatePlanType.Nightly;
        }
    }
}
