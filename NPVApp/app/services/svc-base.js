function svcBase(controller) {
    this.controller = controller;

}

function nullReplacer(key, value) {
    return (value === null) ? undefined : value;
}

$.authGet = function (url) {
    return $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: url,
        //headers: { Authorization: "Bearer " + vueSvc.auth.authToken() },
        error: function (error) {
            //redirectToLoginPage(error);
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
        //headers: { Authorization: "Bearer " + vueSvc.auth.authToken() },
        error: function (error) {
            //redirectToLoginPage(error);
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
        //headers: { Authorization: "Bearer " + vueSvc.auth.authToken() },
        error: function (error) {
            //redirectToLoginPage(error);
        }
    });
};

$.authDelete = function (url) {

    return $.ajax({
        type: "DELETE",
        contentType: "application/json; charset=utf-8",
        url: url,
        //headers: { Authorization: "Bearer " + vueSvc.auth.authToken() },
        error: function (error) {
            //redirectToLoginPage(error);
        }
    });
};