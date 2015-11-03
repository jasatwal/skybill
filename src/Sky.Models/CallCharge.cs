using System;

namespace Sky
{
    public class CallCharge : IBillItem
    {
        private readonly TelephoneNumber number;
        private readonly TimeSpan duration;
        private readonly Money cost;

        public TelephoneNumber Number
        {
            get { return number; }
        }

        public TimeSpan Duration
        {
            get { return duration; }
        }

        public Money Cost
        {
            get { return cost; }
        }

        public CallCharge(TelephoneNumber number, TimeSpan duration, Money cost)
        {
            Check.Argument.IsNotNull(number, nameof(number));
            Check.Argument.IsNotNull(cost, nameof(cost));

            this.number = number;
            this.duration = duration;
            this.cost = cost;
        }
    }
}
