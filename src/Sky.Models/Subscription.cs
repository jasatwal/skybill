namespace Sky
{
    public class Subscription : ICost
    {
        private readonly string type;
        private readonly string name;
        private readonly Money cost;

        public string Type
        {
            get { return type; }
        }

        public string Name
        {
            get { return name; }
        }

        public Money Cost
        {
            get { return cost; }
        }

        public Subscription(string type, string name, Money cost)
        {
            Check.Argument.IsNotNullOrWhiteSpace(type, nameof(type));
            Check.Argument.IsNotNullOrWhiteSpace(name, nameof(name));
            Check.Argument.IsNotNull(cost, nameof(cost));

            this.type = type;
            this.name = name;
            this.cost = cost;
        }
    }
}
