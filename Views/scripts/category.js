function sendAjaxRequest(method, url, data) {
    return $.ajax({
        type: method,
        url: url,
        data: data ? JSON.stringify(data) : null,
        dataType: "application/json",
        error: response => console.log(response)
    });
}

$(document).ready(function () {
    //sendAjaxRequest('Get', 'https://localhost:5001/wapi/category/get');

    $(document).on('input', '#units-range', function() {
        $('#value-span').html( $(this).val() );
    });
 
}); 