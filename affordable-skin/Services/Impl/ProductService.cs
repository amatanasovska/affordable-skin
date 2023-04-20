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
    
}