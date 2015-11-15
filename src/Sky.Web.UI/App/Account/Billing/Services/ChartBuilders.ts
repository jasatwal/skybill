module App.Account.Billing.Services {
    export interface IChartBuilder {
        build(): Array<Directives.IMorrisChart>;
    }

    export class PackageChartsBuilder implements IChartBuilder {
        constructor(private bill: Bill) {
        }

        public build(): Array<Directives.IMorrisChart> {
            var data = [];
            var subscriptions = this.bill.Package.Subscriptions;
            for (var key in subscriptions) {
                var subscription = subscriptions[key];
                data.push({
                    value: subscription.Cost,
                    label: subscription.Name
                });
            }

            return [{
                name: "Subscriptions", 
                data: data
            }]
        }
    }

    export class CallChargesChartsBuilder implements IChartBuilder {
        constructor(private value: IBillWithStatistics) {
        }

        public build(): Array<Directives.IMorrisChart> {
            var data = [];
            for (var key in this.value.CalledFrequency) {
                var entry = this.value.CalledFrequency[key];
                data.push({
                    value: entry.Frequency,
                    label: entry.Number
                });
            }

            return [{
                name: "Called frequency",
                data: data
            }];
        }
    }

    export class SkyStoreChartsBuilder implements IChartBuilder {
        constructor(private value: IBillWithStatistics) {
        }

        public build(): Array<Directives.IMorrisChart> {
            return null;
        }
    }
}