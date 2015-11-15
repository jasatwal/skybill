module App.Account.Billing.Services {
    export interface IChartBuilder {
        build(): Array<Directives.IMorrisChart>;
    }

    export function moneyFormatter(value: any) {
        if (value) {
            if (typeof (value) == "number") {
                return value.toFixed(2);
            }
        }

        return value;
    }

    export function timesFormatter(value: any) {
        if (value) {
            return "x" + value;
        }
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
                description: "View cost of subscription charges.",
                data: data,
                formatter: moneyFormatter
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
                name: "Regularly called numbers",
                description: "View numbers you call the most.",
                data: data,
                formatter: timesFormatter
            }];
        }
    }

    export class SkyStoreChartsBuilder implements IChartBuilder {
        constructor(private value: IBillWithStatistics) {
        }

        public build(): Array<Directives.IMorrisChart> {
            var data = [];
            for (var key in this.value.SkyStoreChargesValue) {
                var entry = this.value.SkyStoreChargesValue[key];
                data.push({
                    value: entry.Value,
                    label: entry.Name
                });
            }

            return [{
                name: "Sky store charges",
                description: "View cost of rentals in relation to buy and keep purchases.",
                data: data,
                formatter: moneyFormatter
            }];
        }
    }
}