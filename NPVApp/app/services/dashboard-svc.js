vueSvc.service("dashboard", function () {
    svcBase.call(this, "dashboard");

    this.getRequests = function (dcId) {
        return $.authGet("/api/npv/requests");
    };
});