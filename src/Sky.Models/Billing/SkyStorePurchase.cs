namespace Sky.Billing
{
    public class SkyStorePurchase : ICost
    {
        private readonly SkyStoreMovie title;
        private readonly Money cost;

        public SkyStoreMovie Title
        {
            get { return title; }
        }

        public Money Cost
        {
            get { return cost; }
        }

        public SkyStorePurchase(SkyStoreMovie title, Money cost)
        {
            Check.Argument.IsNotNull(title, nameof(title));
            Check.Argument.IsNotNull(cost, nameof(cost));

            this.title = title;
            this.cost = cost;
        }
    }
}
