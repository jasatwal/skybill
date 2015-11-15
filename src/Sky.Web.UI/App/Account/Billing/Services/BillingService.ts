module App.Account.Billing.Services {
    export interface ICalledFrequency {
        Frequency: number;
        Number: string;
    }

    export interface ISkyStoreChargeValue {
        Name: string;
        Value: number;
    }

    export interface IBillWithStatistics {
        Bill: Bill;
        CalledFrequency: Array<ICalledFrequency>;
        SkyStoreChargesValue: Array<ISkyStoreChargeValue>;
    }

    export class BillingService {
        http: ng.IHttpService

        static $inject = ["$http"];
        constructor($http: ng.IHttpService) {
            this.http = $http;
        }

        public getBillWithStatistics(): ng.IPromise<IBillWithStatistics> {
            return this.http.post<IBillWithStatistics>("/Account/GetBillWithStatistics", null)
                .then((response: ng.IHttpPromiseCallbackArg<IBillWithStatistics>) => {
                    return response.data;
                });
        }
    }
}