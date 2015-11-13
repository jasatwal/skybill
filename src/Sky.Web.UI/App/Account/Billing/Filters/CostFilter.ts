module App.Account.Billing.Filters {
    export function costFilter() {
        return (value: any) => {
            if (value) {
                if (typeof (value) == "number") {
                    return value.toFixed(2);
                }
            }

            return value;
        };
    }
}