using affordable_skin.Models;
using affordable_skin.Repositories;

namespace affordable_skin.Services.Impl;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<Product> FindAll() => (List<Product>)_productRepository.FindAll();
    public List<ProductPrice> GetLatestPricesById(int id) => (List<ProductPrice>)_productRepository.FindLatestPricesByProductId(id);

    public List<Product> GetProductsByBrandName(string brand) =>
        (List<Product>)_productRepository.GetProductsByBrandName(brand);
}