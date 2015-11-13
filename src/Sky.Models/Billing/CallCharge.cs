using System;

namespace Sky
{
    public class CallCharge : ICost
    {
        private readonly TelephoneNumber called;
        private readonly TimeSpan duration;
        private readonly Money cost;

        public TelephoneNumber Called
        {
            get { return called; }
        }

        public TimeSpan Duration
        {
            get { return duration; }
        }

        public Money Cost
        {
            get { return cost; }
        }

        public CallCharge(TelephoneNumber called, TimeSpan duration, Money cost)
        {
            Check.Argument.IsNotNull(called, nameof(called));
            Check.Argument.IsNotNull(cost, nameof(cost));

            this.called = called;
            this.duration = duration;
            this.cost = cost;
        }
    }
}
