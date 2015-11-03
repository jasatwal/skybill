namespace Sky
{
    public class Package : IBill
    {
        private readonly Subscription tvSubscription;
        private readonly Subscription talkSubscription;
        private readonly Subscription broadbandSubscription;
        private readonly BillSummary summary;

        public Subscription TvSubscription
        {
            get { return tvSubscription; }
        }

        public Subscription TalkSubscription
        {
            get { return talkSubscription; }
        }

        public Subscription BroadbandSubscription
        {
            get { return broadbandSubscription; }
        }

        public BillSummary Summary
        {
            get { return summary; }
        }

        public Package(Subscription tvSubscription, Subscription talkSubscription, Subscription broadbandSubscription, Money total)
        {
            Check.Argument.AtLeastOneIsNotNull("At least one subscription must be supplied.", tvSubscription, talkSubscription, broadbandSubscription);
            Check.Argument.IsNotNull(total, nameof(total));

            this.tvSubscription = tvSubscription;
            this.talkSubscription = talkSubscription;
            this.broadbandSubscription = broadbandSubscription;

            var subTotal = 0M;
            subTotal += (tvSubscription?.Cost.Value).GetValueOrDefault();
            subTotal += (talkSubscription?.Cost.Value).GetValueOrDefault();
            subTotal += (broadbandSubscription?.Cost.Value).GetValueOrDefault();

            summary = new BillSummary(subTotal, total);
        }

        // TODO: Should line rental be added as a subscription charge because its usually itemised on a bill?
    }
}