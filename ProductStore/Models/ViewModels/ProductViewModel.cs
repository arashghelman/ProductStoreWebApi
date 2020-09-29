using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductStore.Models.DomainModels.EF.DTO;
public class ProductViewModel
{
    public ProductViewModel()
    {
        _productRepository = new ProductRepository();
    }

    private ProductRepository _productRepository;
    private Product _product;

    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Title { get; set; }
    public int UnitsInStock { get; set; }
    public decimal PricePerUnit { get; set; }
    public decimal Discount { get; set; }
    public byte[] Photo { get; set; }


    public async Task<List<ProductViewModel>> Select_Product() 
    {
        var productList = await _productRepository.Select();
        var productViewModelList = productList.Select(p => new ProductViewModel()
        {
            Id = p.Id,
            CategoryId = p.CategoryId,
            CategoryName = p.Category.Name,
            Title = p.Name,
            UnitsInStock = p.UnitsInStock,
            PricePerUnit = p.UnitPrice,
            Discount = p.Discount,
            Photo = p.Photo
        }).ToList();

        return productViewModelList;
    }

    public async Task Add_Product(ProductViewModel productViewModel) {
        
        _product = new Product() {
            CategoryId = productViewModel.CategoryId,
            Name = productViewModel.Title,
            UnitsInStock = productViewModel.UnitsInStock,
            UnitPrice = productViewModel.PricePerUnit,
            Discount = productViewModel.Discount,
            Photo = productViewModel.Photo
        };

        await _productRepository.Insert(_product);
    }
}