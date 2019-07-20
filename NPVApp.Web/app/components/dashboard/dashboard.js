var dashboardComponent = Vue.component('dashboard', function (resolve, reject) {
    var vm;

    function data() {
        return {
            calculateNPVRequests: [],
            errors: [],
            loading: false,
        };
    }

    function created() {
        vm = this;
        loadCalculateRequests();
    }

    function mounted() {


    }

    function loadCalculateRequests() {
        vm.loading = true;

        vueSvc.dashboard.getRequests().done(function (data) {
            vm.loading = false;
            vm.calculateNPVRequests = data;
        });

    }

    function viewCalculateRequest(requestId) {
        vueTo(vm, "/calculate/result/" + requestId);
    }

    function goToCalculate() {
        vueTo(vm, "/calculate");
    }

    vueSvc.templates.load("dashboard/dashboard.html").done(function (template) {
        resolve({
            name: "dashboard",
            data: data,
            template: template,
            methods: {
                loadCalculateRequests: loadCalculateRequests,
                viewCalculateRequest: viewCalculateRequest,
                goToCalculate: goToCalculate
            },
            created: created,
            mounted: mounted
        });
    });

});