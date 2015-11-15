angular.module("app", [])
    .filter(App.Account.Billing.Filters)
    .directive(App.Account.Billing.Directives)
    .service("billingService", App.Account.Billing.Services.BillingService)
    .service("billSectionService", App.Account.Billing.Services.BillSectionService)
    .controller("App.Account.Billing.Controllers.OverviewController", App.Account.Billing.Controllers.OverviewController);