using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky
{
    public class BillSummary
    {
        private readonly Money subTotal;
        private readonly Money adjustment;
        private readonly Money total;

        public Money SubTotal
        {
            get { return subTotal; }
        }

        public Money Adjustment
        {
            get { return adjustment; }
        }

        public Money Total
        {
            get { return total; }
        }

        public BillSummary(Money subTotal, Money total)
        {
            Check.Argument.IsNotNull(subTotal, nameof(subTotal));
            Check.Argument.IsNotNull(total, nameof(total));

            this.subTotal = subTotal;
            this.total = total;

            adjustment = total.Subtract(subTotal);
        }
    }
}
