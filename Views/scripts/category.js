function sendAjaxRequest(method, url, data) {
    return $.ajax({
        type: method,
        url: url,
        data: data ? JSON.stringify(data) : null,
        dataType: "application/json",
        headers: {'Access-Control-Allow-Origin': '*'},
        success: function (response) {
            console.log(response);
          },
        error: function (error) {
            console.log(error);
        }
    });
}

$(document).ready(function () {
    sendAjaxRequest('Get', 'https://localhost:5001/wapi/category/get');
});