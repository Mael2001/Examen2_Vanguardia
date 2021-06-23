namespace Hotel.Rates.Data.Rules
{
    public abstract class BaseRule
    {
        public double GetPrice(RatePlan ratePlan, int days)
        {
            if (ratePlan.RatePlanType>-1)
            {
                return CalculatePrice(ratePlan, days);
            }
            return 0;
        }

        public abstract double CalculatePrice(RatePlan ratePlan, int days);
    }
}