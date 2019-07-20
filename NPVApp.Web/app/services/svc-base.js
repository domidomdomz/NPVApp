function svcBase(controller) {
    this.controller = controller;

}

function nullReplacer(key, value) {
    return value === null ? undefined : value;
}

function getResponseErrors(data) {
    var error = {};

    if (data.responseJSON && data.responseJSON.Errors) {
        return data.responseJSON.Errors;
    }
    else if (data.responseJSON) {
        error = {
            Key: "",
            Message: data.responseJSON.ExceptionMessage || data.responseJSON.Message
        };
        var errors = [error];
        return errors;
    }
    else {
        error = {
            Key: "",
            Message: data.responseText || data.statusText
        };
        errors = [error];
        return errors;
    }
};

$.authGet = function (url) {
    return $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: url,
        error: function (error) {
            console.log(error);
        }
    });
};

$.authPost = function (url, data) {
    var json = JSON.stringify(data, nullReplacer);
    return $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: url,
        data: json,
        error: function (error) {
            console.log(error);
        }
    });
};

$.authPut = function (url, data) {

    var json = JSON.stringify(data, nullReplacer);
    return $.ajax({
        type: "PUT",
        contentType: "application/json; charset=utf-8",
        url: url,
        data: json,
        error: function (error) {
            console.log(error);
        }
    });
};

$.authDelete = function (url) {

    return $.ajax({
        type: "DELETE",
        contentType: "application/json; charset=utf-8",
        url: url,
        error: function (error) {
            console.log(error);
        }
    });
};