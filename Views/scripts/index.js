
async function convertToBase64(file) {
    return new Promise(function(resolve, reject){
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result);
        reader.onerror = error => reject(error);
    });
}

var product = new Object();
var productResult = new Object();

$(document).ready(function () { 

    $('.table-div').hide();
    $('#details').hide();

    axios.get('https://localhost:5001/wapi/category')
        .then((response) => {
            var categoryList = response.data;
            $.each(categoryList, function (_, value) { 
                 $('#category-select').append('<option value=' + value.id + '>' + value.title + '</option>');
            });
        });
        axios.get('https://localhost:5001/wapi/product')
            .then((response) => {
                $('.table-div').fadeIn('slow');
                productResult = response.data;
                console.log(productResult);
                productResult.forEach(element => {   
                        $('#product-table > tbody').append(`<tr><th id='id-cell' hidden scope='row'>${element.id}</th>` +
                        `<td>${element.title}</td>` +
                        `<td>${element.categoryName}</td>` +
                        `<td>$${element.pricePerUnit}</td>` +
                        `<td><button id="details-button">See Details</button></td></tr>`);  
                });
            });
        
    $(document).on('input', '#product-unit', function() {
        $('#value-span').html( $(this).val());
    });
    $(document).on('click', '#details-button', function() {
        var $this = $(this);
        var productId = $this.closest('tr').find('#id-cell').text();
        var result = productResult.filter(obj => obj.id == productId);
        $('#detail-title').html(result[0].title);
        $('#detail-category').html(result[0].categoryName);
        $('#detail-units').html(result[0].unitsInStock);
        $('#detail-price').html(result[0].pricePerUnit);
        $('#detail-discount').html(result[0].discount);
        $('#detail-image').attr('src', 'data:image/png;base64,' + result[0].photo);
        $('#details').fadeIn('slow');
    });
    document.querySelector('.custom-file-input').addEventListener('change',function(e){
        var fileName = document.getElementById("product-photo").files[0].name;
        var nextSibling = e.target.nextElementSibling
        nextSibling.innerText = fileName

        const file = document.querySelector('.custom-file-input').files[0];
        convertToBase64(file).then((result) => {
            product.photo = result.split(',').pop();
        });
      });

      $('#category-select').change(function() {
          product.categoryId = $(this).children(':selected').attr('value');
      });

      $('#btn-add').click(function () { 
          product.title = $('#product-title').val();
          product.unitsInStock = $('#value-span').html();
          product.pricePerUnit = $('#product-price').val();
          product.discount = $('#product-discount').val();

          axios.post('https://localhost:5001/wapi/product', {product: product})
            .then(() => {
                alert('Object inserted successfully.');
                location.reload();
            })
            .catch((error) => alert(error.message));
      });
}); 