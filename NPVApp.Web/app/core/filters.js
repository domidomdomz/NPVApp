Vue.filter("money", function (number, decimalSize) {
    return parseFloat(number, 10).toFixed(decimalSize).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
});

Vue.filter('shortDateTimeWithSeconds', function (value) {
    if (value) {
        return moment(String(value)).format('DD/MMM/YYYY hh:mm:ss a');
    }
});