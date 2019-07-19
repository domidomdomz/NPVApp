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

        //var currentDCId = 0;
        //if (vueSvc.auth.currentDC() && vueSvc.auth.currentDC().Id) {
        //    currentDCId = vueSvc.auth.currentDC().Id;
        //}

        vm.calculateNPVRequests = [
            {
                "InitialInvestment": 10000,
                "LowerBoundDiscountRate": 0.01,
                "UpperBoundDiscountRate": 0.015,
                "DiscountRateIncrement": 0.0025,
                "CashFlows": [
                    {
                        "RequestId": 1,
                        "CashFlowValue": 1000,
                        "CashFlowOrder": 1
                    },
                    {
                        "RequestId": 1,
                        "CashFlowValue": 1500,
                        "CashFlowOrder": 2
                    },
                    {
                        "RequestId": 1,
                        "CashFlowValue": 2000,
                        "CashFlowOrder": 3
                    }
                ],
                "CashFlowValues": "1,000.00, 1,500.00, 2,000.00",
                "Id": 1,
                "CreateDate": "2019-07-17T15:09:27.55"
            },
            {
                "InitialInvestment": 500000,
                "LowerBoundDiscountRate": 0.1,
                "UpperBoundDiscountRate": 0.1,
                "DiscountRateIncrement": 0,
                "CashFlows": [
                    {
                        "RequestId": 7,
                        "CashFlowValue": 200000,
                        "CashFlowOrder": 1
                    },
                    {
                        "RequestId": 7,
                        "CashFlowValue": 300000,
                        "CashFlowOrder": 2
                    },
                    {
                        "RequestId": 7,
                        "CashFlowValue": 200000,
                        "CashFlowOrder": 3
                    }
                ],
                "CashFlowValues": "200,000.00, 300,000.00, 200,000.00",
                "Id": 7,
                "CreateDate": "2019-07-18T02:55:21.86"
            },
            {
                "InitialInvestment": 10000,
                "LowerBoundDiscountRate": 0.01,
                "UpperBoundDiscountRate": 0.015,
                "DiscountRateIncrement": 0.0025,
                "CashFlows": [
                    {
                        "RequestId": 8,
                        "CashFlowValue": 10000,
                        "CashFlowOrder": 1
                    },
                    {
                        "RequestId": 8,
                        "CashFlowValue": 15000,
                        "CashFlowOrder": 2
                    },
                    {
                        "RequestId": 8,
                        "CashFlowValue": 20000,
                        "CashFlowOrder": 3
                    }
                ],
                "CashFlowValues": "10,000.00, 15,000.00, 20,000.00",
                "Id": 8,
                "CreateDate": "2019-07-19T03:06:44.32"
            }
        ];


        //vueSvc.dashboard.getRequests().done(function (data) {
        //    vm.loading = false;
        //    vm.calculateNPVRequests = data;
        //});

    }


    vueSvc.templates.load("dashboard/dashboard.html").done(function (template) {
        resolve({
            name: "dashboard",
            data: data,
            template: template,
            methods: {
                //getError: getError,
                //search: search,
                //switchDC: switchDC
            },
            created: created,
            mounted: mounted
        });
    });

});