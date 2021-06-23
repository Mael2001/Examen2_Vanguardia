using Hotel.Rates.Data.Enum;

namespace Hotel.Rates.Data.Rules
{
    public class NightlyRule: BaseRule
    {
        public override double CalculatePrice(RatePlan ratePlan, int days)
        {
            if (ratePlan.RatePlanType == (int) RatePlanType.Nightly)
            {
                return ratePlan.Price * days;
            }

            return 0;
        }
    }
}