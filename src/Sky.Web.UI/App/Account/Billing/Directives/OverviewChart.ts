module App.Account.Billing.Directives {
    // Don't have DefinatelyType file for Morris.js
    declare var Morris: any;  

    export interface IMorrisChart {
        name: string;
        data: Array<any>;
        formatter?: (value: any) => any;
    }

    interface IOverviewChartScope extends ng.IScope {
        overviewChart: IMorrisChart;
    }

    export function overviewChart(): ng.IDirective {
        return {
            scope: {
                overviewChart: "="
            },
            link: (scope: IOverviewChartScope, element: ng.IAugmentedJQuery, attrs: ng.IAttributes) => {
                scope.$watch("overviewChart", (newVal: IMorrisChart, oldVal: IMorrisChart, scope: ng.IScope) => {
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