vueSvc.service("dashboard", function () {
    svcBase.call(this, "dashboard");

    this.getRequests = function () {
        return $.authGet("/api/npv/requests");
    };

    this.getRequestById = function (requestId) {
        return $.authGet("/api/npv/requests?id=" + requestId);
    };

    this.newCalculateNPVRequest = function () {
        return {
            Id: 0,
            InitialInvestment: 0.00,
            LowerBoundDiscountRate: 0.01,
            UpperBoundDiscountRate: 0.01,
            DiscountRateIncrement: 0.01,
            CashFlows: [{ CashFlowValue: 0.00 }]
        };
    };

    this.newCashFlow = function () {
        return {
            CashFlowValue: 0.00
        }
    };
});