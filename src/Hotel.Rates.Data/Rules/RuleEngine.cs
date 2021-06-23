using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Hotel.Rates.Data.Rules
{
    public class RuleEngine
    {
        private readonly IEnumerable<BaseRule> _rules = new List<BaseRule>();

        public RuleEngine(IEnumerable<BaseRule> rules)
        {
            _rules = rules;
        }
        public double GetPrice(RatePlan ratePlan, int days)
        {
            foreach (var rule in _rules)
            {
                if (rule.GetPrice(ratePlan, days)!=0)
                {
                    return rule.GetPrice(ratePlan, days);
                }
            }
            return 0;
        }

        public class Builder
        {
            private readonly List<BaseRule> _rules = new List<BaseRule>();

            public Builder WithNightlyBuilder()
            {
                _rules.Add(new NightlyRule());
                return this;
            }
            public Builder WithIntervalBuilder()
            {
                _rules.Add(new IntervalRule());
                return this;
            }

            public RuleEngine Build()
            {
                return new RuleEngine(_rules);
            }
        }
    }
}