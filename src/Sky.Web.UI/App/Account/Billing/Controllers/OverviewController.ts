module App.Account.Billing.Controllers {
    interface OverviewControllerScope extends ng.IScope {
        bill: any;
        overviewChartData: Array<CircularChartData>;
    }

    export class OverviewController {
        static $inject = ["$scope", "$http"];
        constructor($scope: OverviewControllerScope, $http: ng.IHttpService) {
            var me = this;
            var x = $http.post("/Account/GetBill", null)
                .then((response: any) => {
                    $scope.bill = response.data;
                    $scope.overviewChartData = me.getOverviewChartData($scope.bill);
                }, (reason: any) => {
                    // TODO: Handle errors.
                });
        }

        private getOverviewChartData(bill: any): Array<CircularChartData> {
            var data = [];

            if (bill.Tv) {
                data.push({
                    value: bill.Tv.Total,
                    label: bill.Tv.Name,
                    color: "#F7464A",
                    highlight: "#FF5A5E"
                });
            }

            if (bill.Talk) {
                data.push({
                    value: bill.Talk.Total,
                    label: bill.Talk.Name,
                    color: "#46BFBD",
                    highlight: "#5AD3D1",
                });
            }

            if (bill.Broadband) {
                data.push({
                    value: bill.Broadband.Total,
                    label: bill.Broadband.Name,
                    color: "#FDB45C",
                    highlight: "#FFC870",
                });
            }

            return data;
        }
    }
}