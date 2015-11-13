using System.Collections.Generic;

namespace Sky.Billing
{
    public class ChargeBreakdownCategory : ICost
    {
        private readonly string name;
        private readonly IEnumerable<ICost> charges;
        private readonly Money cost;

        public string Name
        {
            get { return name; }
        }

        public IEnumerable<ICost> Charges
        {
            get { return charges; }
        }
        
        public Money Cost
        {
            get { return cost; }
        }

        public ChargeBreakdownCategory(string name, IEnumerable<ICost> charges)
        {
            Check.Argument.IsNotNullOrWhiteSpace(name, nameof(name));
            Check.Argument.IsNotNull(charges, nameof(charges));

            this.name = name;
            this.charges = charges;

            cost = charges.Sum();
        }
    }
}
