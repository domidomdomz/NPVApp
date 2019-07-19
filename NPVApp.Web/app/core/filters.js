Vue.filter("money", function (number, decimalSize) {
    return parseFloat(number, 10).toFixed(decimalSize).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
});

Vue.filter("percentage", function (value, decimals) {
    if (!value) value = 0;
    if (!decimals) decimals = 0;

    value = value * 100;
    return Math.round(value * Math.pow(10, decimals)) / Math.pow(10, decimals) + "%";
});

Vue.filter('shortDateTimeWithSeconds', function (value) {
    if (value) {
        return moment(String(value)).format('DD/MMM/YYYY hh:mm:ss a');
    }
});