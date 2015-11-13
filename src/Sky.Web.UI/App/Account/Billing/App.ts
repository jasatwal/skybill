angular.module("app", [])
    .filter(App.Account.Billing.Filters)
    .directive(App.Account.Billing.Directives)
    .controller("App.Account.Billing.Controllers.OverviewController", App.Account.Billing.Controllers.OverviewController);