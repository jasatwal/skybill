namespace Sky
{
    public class Subscription
    {
        private readonly string name;
        private readonly Money cost;

        public string Name
        {
            get { return name; }
        }

        public Money Cost
        {
            get { return cost; }
        }

        public Subscription(string name, Money cost)
        {
            Check.Argument.IsNotNullOrWhiteSpace(name, nameof(name));
            Check.Argument.IsNotNull(cost, nameof(cost));

            this.name = name;
            this.cost = cost;
        }
    }
}
