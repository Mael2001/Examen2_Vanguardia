using System.Runtime.Serialization.Formatters;
using Hotel.Rates.Data.Enum;

namespace Hotel.Rates.Data.Rules
{
    public class IntervalRule: BaseRule
    {
        public override double CalculatePrice(RatePlan ratePlan, int days)
        {
            if (ratePlan.RatePlanType== (int) RatePlanType.Interval)
            {
                if (days>2)
                {
                    var pricePerDay = ratePlan.Price / days;
                    return pricePerDay;
                }
            }
            return 0;
        }
    }
}