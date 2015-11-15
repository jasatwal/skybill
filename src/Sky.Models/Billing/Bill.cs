namespace Sky.Billing
{
    public class Bill : IBill
    {
        private readonly Statement statement;
        private readonly PackageBill package;
        private readonly CallChargesBill callCharges;
        private readonly SkyStoreBill skyStore;
        private readonly BillCostings costings;

        public Statement Statement
        {
            get { return statement; }
        }

        public PackageBill Package
        {
            get { return package; }
        }

        public CallChargesBill CallCharges
        {
            get { return callCharges; }
        }

        public SkyStoreBill SkyStore
        {
            get { return skyStore; }
        }

        public BillCostings Costings
        {
            get { return costings; }
        }

        public Bill(Statement statement,
                    PackageBill package,
                    CallChargesBill callCharges,
                    SkyStoreBill skyStore,
                    Money total)
        {
            Check.Argument.IsNotNull(statement, nameof(statement));
            Check.Argument.IsNotNull(package, nameof(package));

            this.statement = statement;
            this.package = package;
            this.callCharges = callCharges;
            this.skyStore = skyStore;

            costings = new BillCostings(
                package.Costings.Total
                    .Add(callCharges?.Costings.Total ?? Money.Zero)
                    .Add(skyStore?.Costings.Total ?? Money.Zero), 
                total);
        }
    }
}
