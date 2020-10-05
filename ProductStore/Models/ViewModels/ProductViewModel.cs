using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductStore.Models.DomainModels.EF.DTO;
public class ProductViewModel
{
    #region [- ctor -]
    public ProductViewModel()
    {
        _productRepository = new ProductRepository();
    }
    #endregion

    #region [- fields -]
        private ProductRepository _productRepository;
        private Product _product;
    #endregion

    #region [- props -]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public int UnitsInStock { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal Discount { get; set; }
        public byte[] Photo { get; set; }
    #endregion

    #region [- Select_ProductDetails(ProductViewModel productViewModel) -]
    public async Task<ProductViewModel> Select_ProductDetails(ProductViewModel productViewModel) 
    {
        _product = await _productRepository.SelectById(productViewModel.Id);
        var productDetails = new ProductViewModel() 
        {
            CategoryId = _product.CategoryId,
            CategoryName = _product.Category.Name,
            Title = _product.Name,
            UnitsInStock = _product.UnitsInStock,
            PricePerUnit = _product.UnitPrice,
            Discount = _product.Discount,
            Photo = _product.Photo
        };

        return productDetails;
    }
    #endregion

    #region [- Select_Product() -]
    public async Task<List<ProductViewModel>> Select_Product() 
    {
        var productList = await _productRepository.Select();
        var productViewModelList = productList.Select(p => new ProductViewModel()
        {
            Id = p.Id,
            Title = p.Name,
            CategoryName = p.Category.Name,
            PricePerUnit = p.UnitPrice
        }).ToList();
    

        return productViewModelList;
    }
    #endregion

    #region [- Add_Product(ProductViewModel productViewModel)  -]
    public async Task Add_Product(ProductViewModel productViewModel) 
    {
        
        _product = new Product() 
        {
            CategoryId = productViewModel.CategoryId,
            Name = productViewModel.Title,
            UnitsInStock = productViewModel.UnitsInStock,
            UnitPrice = productViewModel.PricePerUnit,
            Discount = productViewModel.Discount,
            Photo = productViewModel.Photo
        };

        await _productRepository.Insert(_product);
    }
    #endregion
    
    #region [- Remove_Product(ProductViewModel productViewModel) -]
    public async Task Remove_Product(ProductViewModel productViewModel) 
    {

        _product = new Product() 
        {
            Id = productViewModel.Id
        };

        await _productRepository.Delete(_product.Id);
    }
    #endregion

    #region [- Edit_Product(ProductViewModel productViewModel) -]
    public async Task Edit_Product(ProductViewModel productViewModel)
    {

        _product = new Product()
        {
            Id = productViewModel.Id,
            CategoryId = productViewModel.CategoryId,
            Name = productViewModel.Title,
            UnitsInStock = productViewModel.UnitsInStock,
            UnitPrice = productViewModel.PricePerUnit,
            Discount = productViewModel.Discount,
            Photo = productViewModel.Photo        
        };

        await _productRepository.Update(_product);
    }
    #endregion
}