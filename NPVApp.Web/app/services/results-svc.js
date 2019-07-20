vueSvc.service("results", function () {
    svcBase.call(this, "results");

    this.getResults = function (requestId) {
        return $.authGet("/api/npv/results?id=" + requestId);
    };

});