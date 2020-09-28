function sendAjaxRequest(method, url, data) {
    return $.ajax({
        type: method,
        url: url,
        data: data ? JSON.stringify(data) : null,
        dataType: "application/json"
    });
}

$(document).ready(function () {
    sendAjaxRequest('Get', 'https://localhost:5001/wapi/category/get');
});