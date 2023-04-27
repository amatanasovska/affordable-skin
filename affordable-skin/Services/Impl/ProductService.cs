using affordable_skin.Models;
using affordable_skin.Models.dto;
using affordable_skin.Repositories;

namespace affordable_skin.Services.Impl;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<ProductDto> FindAll()
    {
        return (List<ProductDto>)_productRepository.FindAll().Select(x =>
            new ProductDto(x.Id, x.Image, x.Name, x.BrandName, x.LowestPrice)).ToList();
    }

    public List<ProductPriceDto> GetLatestPricesById(int id)
    {
        
        List<ProductPrice> listProdPrice = (List<ProductPrice>)_productRepository.FindLatestPricesByProductId(id);

        return listProdPrice.Select(x =>
            new ProductPriceDto(x.Id, x.Name, x.SellerName, x.Date, x.Price, x.LinkToProduct)).ToList();
    }

    public List<ProductDto> GetProductsByBrandName(string brand) =>
        (List<ProductDto>)_productRepository.GetProductsByBrandName(brand).Select(x =>
            new ProductDto(x.Id, x.Image, x.Name, x.BrandName, x.LowestPrice)).ToList();

    public List<ProductDto> Search(string query)
    {
        List<ProductDto> ByBrand = _productRepository.GetProductsByBrandNameContaining(query).Select(x =>
            new ProductDto(x.Id, x.Image, x.Name, x.BrandName, x.LowestPrice)).ToList();
        List<ProductDto> ByName = _productRepository.GetProductsByNameContaining(query).Select(x =>
            new ProductDto(x.Id, x.Image, x.Name, x.BrandName, x.LowestPrice)).ToList();

        ByBrand.InsertRange(0,ByName);
        return ByBrand;
    }
}