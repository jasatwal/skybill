module App.Account.Billing.Filters {
    export function breakdownFilter() {
        return (value: any) => {
            if (value) {
                if (typeof (value) == "number") {
                    return value.toFixed(2);
                } else {
                    return value;
                }
            }

            return null;
        }
    }
}