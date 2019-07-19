vueSvc.service("templates", function () {
    this.load = function (template) {
        return $.get("/app/components/" + template + "?v=" + BuildDate);
    }
});
