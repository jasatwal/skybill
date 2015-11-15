module App.Account.Billing {
    // These interfaces are used for compile time checking, not actually required for the application to work.

    export interface IPeriod {
        To: Date;
        From: Date
    }

    export interface ICost {
        Cost: number;
    }

    export interface IStatement {
        Generated: Date;
        Due: Date;
        Period: IPeriod;
    }

    export interface IBillCostings {
        SubTotal: number;
        Adjustment: number;
        Total: number;
    }

    export interface ISubscription extends ICost {
        Type: string;
        Name: string;
    }

    export interface ICallCharge extends ICost {
        Called: string;
        Duration: string;
    }

    export interface ISkyStorePurchase extends ICost {
        Title: string;
    }

    export interface IBill {
        Costings: IBillCostings;
    }

    export interface IPackageBill extends IBill {
        Subscriptions: Array<ISubscription>
    }

    export interface ICallChargesBill extends IBill {
        Calls: Array<ICallCharge>;
    }

    export interface ISkyStoreBill extends IBill {
        Rentals: Array<ISkyStorePurchase>;
        BuyAndKeep: Array<ISkyStorePurchase>;
    }

    export interface Bill {
        Statement: IStatement;
        Package: IPackageBill;
        CallCharges: ICallChargesBill;
        SkyStore: ISkyStoreBill;
    }
}