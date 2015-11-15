module App.Account.Billing.Directives {
    // Don't have DefinatelyType file for Morris.js ;(
    declare var Morris: any;  

    export interface IMorrisChart {
        name: string;
        description?: string;
        data: Array<any>;
        formatter?: (value: any) => any;
    }

    interface IOverviewChartScope extends ng.IScope {
        overviewChart: IMorrisChart;
    }

    export function chart(): ng.IDirective {
        return {
            scope: {
                chart: "="
            },
            link: (scope: IOverviewChartScope, element: ng.IAugmentedJQuery, attrs: ng.IAttributes) => {
                scope.$watch("chart", (newVal: IMorrisChart, oldVal: IMorrisChart, scope: ng.IScope) => {
                    if (newVal) {
                        var chart = Morris.Donut({
                            element: element.get(0),
                            data: newVal.data,
                            formatter: newVal.formatter 
                        });
                    }
                });
            }
        }
    }
}