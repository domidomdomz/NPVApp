vueSvc.service("calculate", function () {
    svcBase.call(this, "calculate");

    this.doCalculateNPV = function (data) {
        return $.authPost("/api/npv/calculate", data);
    }

});