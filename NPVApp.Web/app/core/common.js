var BuildDate = new Date().getTime();

function vueTo(vm, route) {
    vm.$router.replace(route);
}

function vueToNewTab(vm, url) {
    var route = vm.$router.resolve({ path: url });
    window.open(route.href, '_blank');
}

function vueInfo(message) {
    message = formatMessage(message);
    globalNotify(message, 'alert alert-success');
}

function vueError(message) {
    message = formatMessage(message);
    globalNotify(message, 'alert alert-danger');
}

function vueWarn(message) {
    message = formatMessage(message);
    globalNotify(message, 'alert alert-warning');
}

function formatMessage(message) {
    return message.replace(/<br>/g, "\n");
}

function globalNotify(message, notifClassName) {
    
    $.notify.addStyle('dataNotifyText', {
        html: "<div><span data-notify-text class='font-12'/></div>",
    });

    $.notify(message, {
        globalPosition: 'top center',
        className: notifClassName,
        position: 'top',
        style: 'dataNotifyText'
    });
    
}

function showGenericError(errors) {
    var error = getErrorByKey(errors, "");
    vueError(error);
}

function getErrorByKey(errors, key) {
    var modelErrors = _.filter(errors, { Key: key });
    var errorStrings = _.map(modelErrors, "Message");
    var result = errorStrings.join(", ");
    return result;
}

function isInputPositiveDecimal(event) {
    return (event.charCode >= 48 && event.charCode <= 57) || event.charCode == 46;
}

// because maxlength property is ignored when input type is number
function applyMaxlength(el) {
    if (el.value.length > el.maxLength)
        el.value = el.value.slice(0, el.maxLength);
}