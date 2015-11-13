using System.Collections.Generic;

namespace Sky.Billing
{
    public class Breakdown : IBreakdown
    {
        private readonly Statement statement;
        private readonly ChargeBreakdown package;
        private readonly IEnumerable<ChargeBreakdown> charges;
        private readonly CostingsBreakdown costings;

        public Statement Statement
        {
            get { return statement; }
        }

        public ChargeBreakdown Package
        {
            get { return package; }
        }

        public IEnumerable<ChargeBreakdown> Charges
        {
            get { return charges; }
        }

        public CostingsBreakdown Costings
        {
            get { return costings; }
        }

        public Breakdown(Statement statement, ChargeBreakdown package, Money total, params ChargeBreakdown[] charges)
        {
            this.statement = statement;
            this.package = package;
            this.charges = charges;

            costings = new CostingsBreakdown(package.Costings.Total.Add(charges.Sum()), total);
        }
    }
}
