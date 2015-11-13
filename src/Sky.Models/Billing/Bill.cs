﻿namespace Sky.Billing
{
    public class Bill : IBill
    {
        private readonly Statement statement;
        private readonly PackageBill package;
        private readonly CallChargesBill callCharges;
        private readonly SkyStore skyStore;
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

        public SkyStore SkyStore
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
                    SkyStore skyStore,
                    Money total)
        {
            Check.Argument.IsNotNull(statement, nameof(statement));
            Check.Argument.IsNotNull(package, nameof(package));
            Check.Argument.IsNotNull(callCharges, nameof(callCharges));
            Check.Argument.IsNotNull(skyStore, nameof(skyStore));

            this.statement = statement;
            this.package = package;
            this.callCharges = callCharges;
            this.skyStore = skyStore;

            costings = new BillCostings(package.Costings.Total.Add(callCharges.Costings.Total).Add(skyStore.Costings.Total), total);
        }

        //public Breakdown Breakdown()
        //{
        //    return new Breakdown(
        //        statement,
        //        package.Breakdown(),
        //        total,
        //        callCharges.Breakdown(),
        //        skyStore.Breakdown());
        //}
    }
}