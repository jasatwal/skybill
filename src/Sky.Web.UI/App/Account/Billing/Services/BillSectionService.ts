module App.Account.Billing.Services {
    export interface IBillSectionChargesGroup {
        name: string;
        charges: Array<ICost>;
    }

    export interface IBillSection {
        name: string;
        chargesGroups: Array<IBillSectionChargesGroup>;
        costings: IBillCostings;
        charts?: Array<App.Account.Billing.Directives.IMorrisChart>;
        template: string;
    }

    export class BillSectionService {
        public getSections(bill: Bill,
            packageChartsBuilder: IChartBuilder,
            callChargesChartsBuilder: IChartBuilder,
            skyStoreChartsBuilder: IChartBuilder): Array<IBillSection> {
            var sections = [];

            sections.push({
                name: "Subscription charges",
                chargesGroups: [{
                    name: "Subscription charges",
                    charges: bill.Package.Subscriptions
                }],
                costings: bill.Package.Costings,
                charts: packageChartsBuilder.build(),
                template: "subscriptionsTemplate"
            });

            sections.push({
                name: "Telephone usage charges",
                chargesGroups: [{
                    name: "Telephone usage charges",
                    charges: bill.CallCharges.Calls
                }],
                costings: bill.CallCharges.Costings,
                charts: callChargesChartsBuilder.build(),
                template: "callChargesTemplate"
            });

            sections.push({
                name: "Sky store charges",
                chargesGroups: [{
                    name: "Rentals",
                    charges: bill.SkyStore.Rentals
                }, {
                    name: "Buy and keep",
                    charges: bill.SkyStore.BuyAndKeep
                    }],
                costings: bill.SkyStore.Costings,
                charts: skyStoreChartsBuilder.build(),
                template: "skyStoreTemplate"
            });

            return sections;
        }
    }
}