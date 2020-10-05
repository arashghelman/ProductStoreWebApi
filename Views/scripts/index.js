
async function convertToBase64(file) {
    return new Promise(function(resolve, reject){
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result);
        reader.onerror = error => reject(error);
    });
}

function disableButton() {
    $('#btn-add').attr('disabled', 'disabled');
};

function enableButton() {
    $('#btn-add').prop('disabled', false);
}

var product = new Object();

$(document).ready(function () { 
    disableButton();

    $('#details').hide();

    axios.get('https://localhost:5001/wapi/category')
        .then((response) => {
            var categoryList = response.data;
            $.each(categoryList, function (key, value) { 
                 $('#category-select').append('<option value=' + key + '>' + value.title + '</option>');
            });
        });
        axios.get('https://localhost:5001/wapi/product')
            .then((response) => {
                var product = response.data;
                product.forEach(element => {   
                        $('#product-table > tbody').append(`<tr><th id='id-cell' hidden scope='row'>${element.id}</th>` +
                        `<td>${element.title}</td>` +
                        `<td>${element.categoryName}</td>` +
                        `<td>${element.pricePerUnit} $</td>` +
                        `<td><button id="details-button">See Details</button></td></tr>`);  
                });
            });
        
    $(document).on('input', '#product-unit', function() {
        $('#value-span').html( $(this).val());
    });
    $(document).on('click', '#details-button', function() {
        var $this = $(this);
        var productId = $this.closest('tr').find('#id-cell').text();
        var product = {
            id: productId
        };
        axios.get('https://localhost:5001/wapi/category', {
            params: {
                product: product
            }
        }).then(() => $('#details').fadeIn('slow'))
    });
    document.querySelector('.custom-file-input').addEventListener('change',function(e){
        var fileName = document.getElementById("product-photo").files[0].name;
        var nextSibling = e.target.nextElementSibling
        nextSibling.innerText = fileName

        const file = document.querySelector('.custom-file-input').files[0];
        console.log(convertToBase64(file));
      });

      $('#product-title').change(function() {
          product.title = $('#product-title').val();
      });
}); 