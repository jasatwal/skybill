module App.Account.Billing.Controllers {
    interface IOverviewControllerScope extends ng.IScope {
        breakdown: Bill;
        calledFrequency: Array<any>;
        overviewCharts: Array<App.Account.Billing.Directives.IOverviewChart>;
        charges: Array<IChargeBreakdown>;
        callChargesCharts: Array<App.Account.Billing.Directives.IOverviewChart>;
    }

    interface IColorCombo {
        color: string;
        highlight: string;
    }

    export class OverviewController {
        colorCombos: Array<IColorCombo> = [{
                color: "#F7464A",
                highlight: "#FF5A5E"
            }, {
                color: "#46BFBD",
                highlight: "#5AD3D1"
            }, {
                color: "#FDB45C",
                highlight: "#FFC870"
            }];

        static $inject = ["$scope", "$http"];
        constructor($scope: IOverviewControllerScope, $http: ng.IHttpService) {
            var me = this;
            $http.post("/Account/GetBill", null)
                .then((response: any) => {
                    console.log(response.data);
                    $scope.breakdown = response.data.Bill;
                    $scope.calledFrequency = response.data.CalledFrequency;
                    $scope.overviewCharts = me.getOverviewCharts($scope.breakdown);
                    $scope.callChargesCharts = me.getCalledFrequencyCharts($scope.calledFrequency);
                    //$scope.charges = me.getCharges($scope.breakdown);
                }, (reason: any) => {
                    // TODO: Handle errors.
                });
        }

        private getOverviewCharts(breakdown: Bill): Array<App.Account.Billing.Directives.IOverviewChart> {
            return [
                this.getPackageOverviewChart(breakdown),
                this.getChargesOverviewChart(breakdown)
            ];
        }

        private getPackageOverviewChart(breakdown: Bill): App.Account.Billing.Directives.IOverviewChart {
            var data = [];
            var packageCharges = breakdown.Package.Subscriptions;
            for (var key in packageCharges) {
                var charge = packageCharges[key];
                var colorCombo = this.colorCombos[key % this.colorCombos.length];
                data.push({
                    value: charge.Cost,
                    label: charge.Name,
                    //color: colorCombo.color,
                    //highlight: colorCombo.highlight
                });
            }

            return {
                name: "Package",
                data: data,
                formatter: (value: any) => {
                    return value.toFixed(2);
                }
            };
        }

        private getChargesOverviewChart(breakdown: Bill): App.Account.Billing.Directives.IOverviewChart {
            var data = [];
            //for (var key in breakdown.Charges) {
            //    var charge = breakdown.Charges[key];
            //    var colorCombo = this.colorCombos[key % this.colorCombos.length];
            //    data.push({
            //        value: charge.Costings.Total,
            //        label: charge.Name,
            //        color: colorCombo.color,
            //        highlight: colorCombo.highlight
            //    });
            //}

            data.push({
                value: breakdown.CallCharges.Costings.Total,
                label: "Call charges",
                //color: "#46BFBD",
                //highlight: "#5AD3D1"
            });

            data.push({
                value: breakdown.SkyStore.Costings.Total,
                label: "Sky store",
                //color: "#FDB45C",
                //highlight: "#FFC870"
            });

            return {
                name: "Charges",
                data: data,
                formatter: (value: any) => {
                    return value.toFixed(2);
                }
            }
        }

        //private getCharges(breakdown: Bill): Array<IChargeBreakdown> {
        //    var data = [];
        //    data.push(breakdown.Package);

        //    for (var key in breakdown.Charges) {
        //        data.push(breakdown.Charges[key]);
        //    }

        //    return data;
        //}

        private getCalledFrequencyCharts(data: Array<any>): Array<App.Account.Billing.Directives.IOverviewChart> {
            var myData = [];
            for (var i in data) {
                myData.push({
                    value: data[i].Frequency,
                    label: data[i].Number
                });
            }

            return [{
                name: "Called frequency",
                data: myData
            }];
        }
    }
}