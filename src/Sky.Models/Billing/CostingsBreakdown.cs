namespace Sky.Billing
{
    public class CostingsBreakdown
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

        public CostingsBreakdown(Money subTotal, Money total)
        {
            Check.Argument.IsNotNull(subTotal, nameof(subTotal));
            Check.Argument.IsNotNull(total, nameof(total));

            this.subTotal = subTotal;
            this.total = total;

            adjustment = total.Subtract(subTotal);
        }
    }
}
