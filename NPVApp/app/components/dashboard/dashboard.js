var dashboardComponent = Vue.component('dashboard', function (resolve, reject) {
    var vm;

    function data() {
        return {
            calculateNPVRequests: [],
            //companyDashboard: null,
            errors: [],
            loading: false,
        };
    }

    function created() {
        vm = this;
        //vm.dashboardTasks = vueSvc.dashboard.newDashboardTask();
        loadData();
    }

    function mounted() {


    }

    function loadData() {
        vm.loading = true;

        
        vueSvc.dashboard.getRequests().done(function (data) {
            vm.loading = false;
            vm.calculateNPVRequests = data;
        });

    }


    vueSvc.templates.load("dashboard/dashboard.html").done(function (template) {
        resolve({
            name: "dashboard",
            data: data,
            template: template,
            methods: {
                //getError: getError,

            },
            created: created,
            mounted: mounted
        });
    });

});