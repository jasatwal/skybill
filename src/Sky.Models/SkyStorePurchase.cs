namespace Sky
{
    public class SkyStorePurchase : IBillItem
    {
        private readonly SkyStoreMovie movie;
        private readonly Money cost;

        public SkyStoreMovie Movie
        {
            get { return movie; }
        }

        public Money Cost
        {
            get { return cost; }
        }

        public SkyStorePurchase(SkyStoreMovie movie, Money cost)
        {
            Check.Argument.IsNotNull(movie, nameof(movie));
            Check.Argument.IsNotNull(cost, nameof(cost));

            this.movie = movie;
            this.cost = cost;
        }
    }
}
