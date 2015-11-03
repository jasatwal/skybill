module App.Account.Billing.Directives {
    interface IOverviewChartScope extends ng.IScope {
        overviewChart: Array<CircularChartData>;
    }

    export function overviewChart(): ng.IDirective {
        return {
            scope: {
                overviewChart: "="
            },
            link: (scope: IOverviewChartScope, element: ng.IAugmentedJQuery, attrs: ng.IAttributes) => {
                scope.$watch("overviewChart", (newVal: Array<CircularChartData>, oldVal: Array<CircularChartData>, scope: ng.IScope) => {
                    if (newVal) {
                        var ctx = (<HTMLCanvasElement>element.get(0)).getContext("2d");
                        var chart = new Chart(ctx).Doughnut(newVal);
                    }
                });
            }
        }
    }
}