using System;

namespace Sky
{
    public class CustomerBill : IBill
    {
        private readonly CustomerAccountNumber customer;
        private readonly DateTime generated;
        private readonly DateTime due;
        private readonly Period period;
        private readonly Package package;
        private readonly CallChargesBill callCharges;
        private readonly SkyStoreBill skyStore;
        private readonly BillSummary summary;

        public CustomerAccountNumber Customer
        {
            get { return customer; }
        }

        public DateTime Generated
        {
            get { return generated; }
        }

        public DateTime Due
        {
            get { return due; }
        }

        public Period Period
        {
            get { return period; }
        }

        public Package Package
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

        public BillSummary Summary
        {
            get { return summary; }
        }

        public CustomerBill(CustomerAccountNumber customer,
                            DateTime generated,
                            DateTime due,
                            Period period,
                            Package package,
                            CallChargesBill callCharges,
                            SkyStoreBill skyStore,
                            Money total)
        {
            Check.Argument.IsNotNull(customer, nameof(customer));
            Check.Argument.IsNotNull(period, nameof(period));
            Check.Argument.IsNotNull(package, nameof(package));
            Check.Argument.IsNotNull(callCharges, nameof(callCharges));
            Check.Argument.IsNotNull(skyStore, nameof(skyStore));

            this.customer = customer;
            this.generated = generated;
            this.due = due;
            this.period = period;
            this.package = package;
            this.callCharges = callCharges;
            this.skyStore = skyStore;

            summary = new BillSummary(package.Summary.Total.Add(callCharges.Summary.Total).Add(skyStore.Summary.Total), total);
        }
    }
}
