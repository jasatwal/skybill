using System.Collections.Generic;

namespace Sky.Billing
{
    public class ChargeBreakdown : IBreakdown
    {
        private readonly string name;
        private readonly CostingsBreakdown costings;
        private readonly IEnumerable<ChargeBreakdownCategory> categories;

        public string Name
        {
            get { return name; }
        }

        public IEnumerable<ChargeBreakdownCategory> Categories
        {
            get { return categories; }
        }

        public CostingsBreakdown Costings
        {
            get { return costings; }
        }

        public ChargeBreakdown(string name, Money total, params ChargeBreakdownCategory[] categories)
        {
            Check.Argument.IsNotNullOrWhiteSpace(name, nameof(name));
            Check.Argument.IsNotNull(categories, nameof(categories));

            this.name = name;
            this.categories = categories;

            costings = new CostingsBreakdown(categories.Sum(), total);
        }
    }
}
