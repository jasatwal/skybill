module App.Account.Billing.Controllers {
    interface IOverviewControllerScope extends ng.IScope {
        bill: Bill;
        billSections: Array<Services.IBillSection>;
    }

    export class OverviewController {
        static $inject = ["$scope", "billingService", "billSectionService"];
        constructor(
            $scope: IOverviewControllerScope,
            billingService: Services.BillingService,
            private billSectionService: Services.BillSectionService) {

            var me = this;
            billingService.getBillWithStatistics().then((value: Services.IBillWithStatistics) => {
                $scope.billSections = me.buildBillSections(value);
                console.log($scope.billSections);
            }, (reason: any) => {
                // TODO: Handle errors.
            });
        }

        private buildBillSections(data: Services.IBillWithStatistics): Array<Services.IBillSection> {
            return this.billSectionService.getSections(data.Bill,
                new Services.PackageChartsBuilder(data.Bill),
                new Services.CallChargesChartsBuilder(data),
                new Services.SkyStoreChartsBuilder(data));
        }
    }
}