
$(document).ready(function () {
    axios.get('https://localhost:5001/wapi/category')
        .then((response) => {
            var categoryList = response.data;
            console.log(response.headers.expires);
            $.each(categoryList, function (key, value) { 
                 $('#category-select').append('<option value=' + key + '>' + value.title + '</option>');
            });
        })
    $(document).on('input', '#product-unit', function() {
        $('#value-span').html( $(this).val() );
    });
 
}); 