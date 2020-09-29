
$(document).ready(function () {
    axios.get('https://localhost:5001/wapi/category/get')
        .then((response) => {
            var categoryList = response.data;
            console.log(response.headers);
            $.each(categoryList, function (key, value) { 
                 $('#category-select').append('<option value=' + key + '>' + value.title + '</option>');
            });
        })
    $(document).on('input', '#units-range', function() {
        $('#value-span').html( $(this).val() );
    });
 
}); 