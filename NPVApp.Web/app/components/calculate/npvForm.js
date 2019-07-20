var npvFormComponent = Vue.component('npv-form', function (resolve, reject) {
    var vm;

    function data() {
        return {
            id: null,
            calculateNPVRequest: vueSvc.dashboard.newCalculateNPVRequest(),
            calculateNPVResults: [],
            saving: false,
            errors: []
        }
    }

    function created() {
        vm = this;

        vm.id = vm.$route.params.id || 0;
        vm.calculateNPVRequest.Id = vm.id;

        if (vm.id) {
            loadCalculateRequest();
            loadCalculateResults();
        }
    }

    function mounted() {
    }

    function addCashFlow(index) {
        vm.errors = [];
        index = index || -1;
        vm.calculateNPVRequest.CashFlows.push(vueSvc.dashboard.newCashFlow());
    }

    function removeCashFlow(index) {
        vm.errors = [];
        vm.calculateNPVRequest.CashFlows.splice(index, 1);
    }

    function getError(key) {
        return getErrorByKey(vm.errors, key);
    }

    function calculateNPV() {

        vm.saving = true;

        var cashFlowsCopy = _.cloneDeep(vm.calculateNPVRequest.CashFlows);
        var cashFlowsTemp = _.map(cashFlowsCopy, function (o) {
            if (o.CashFlowValue != undefined) return o.CashFlowValue;
        });
        
        var calculateNPVApiRequest = {
            InitialInvestment: vm.calculateNPVRequest.InitialInvestment,
            LowerBoundDiscountRate: vm.calculateNPVRequest.LowerBoundDiscountRate,
            UpperBoundDiscountRate: vm.calculateNPVRequest.UpperBoundDiscountRate,
            DiscountRateIncrement: vm.calculateNPVRequest.DiscountRateIncrement,
            CashFlows: cashFlowsTemp
        };

        vueSvc.calculate.doCalculateNPV(calculateNPVApiRequest).done(function (data) {
            vm.id = data;
            vueInfo("NPV successfully computed.");
            vueTo(vm, "/calculate/result/" + data);
            vm.saving = false;

        }).fail(function (data) {
            vm.errors = getResponseErrors(data);
            showGenericError(vm.errors);
            vm.saving = false;
        });
    }

    function loadCalculateRequest() {

        vueSvc.dashboard.getRequestById(vm.id).done(function (data) {
            vm.calculateNPVRequest = data;

        }).fail(function (data) {
            vm.errors = getResponseErrors(data);
            showGenericError(vm.errors);
            vm.saving = false;
        });

    }

    function loadCalculateResults() {

        vueSvc.results.getResults(vm.id).done(function (data) {
            vm.calculateNPVResults = data;

        }).fail(function (data) {
            vm.errors = getResponseErrors(data);
            showGenericError(vm.errors);
            vm.saving = false;
        });
   
    }

    vueSvc.templates.load("calculate/npvForm.html").done(function (template) {
        resolve({
            name: "npv-form",
            data: data,
            template: template,
            methods: {
                addCashFlow: addCashFlow,
                getError: getError,
                removeCashFlow: removeCashFlow,
                calculateNPV: calculateNPV,
                loadCalculateRequest: loadCalculateRequest
            },
            created: created,
            mounted: mounted
        })
    });

});