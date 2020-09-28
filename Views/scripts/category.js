function sendAjaxRequest(method, url, data) {
    var eTag = sessionStorage.getItem("eTag");
    return $.ajax({
        type: method,
        url: url,
        data: data ? JSON.stringify(data) : null,
        dataType: "application/json",
        headers: { 'If-None-Match': eTag ? sessionStorage.getItem("ETag") : null },
        success: function (request) {
            sessionStorage.setItem("eTag", request.getResponseHeader("ETag"))
            console.log(request.data);
          },
        error: function (error) {
            console.log(error);
        }
    });
}

$(document).ready(function () {
    console.log('here')
    sendAjaxRequest('Get', 'https://localhost:5001/wapi/category/get');
});