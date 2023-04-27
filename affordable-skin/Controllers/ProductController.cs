using affordable_skin.Models;
using affordable_skin.Models.dto;
using affordable_skin.Repositories.Impl;
using affordable_skin.Services;
using affordable_skin.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace affordable_skin.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController :ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;
    public ProductController(ILogger<ProductController> logger,IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }
    [HttpGet]
    public IEnumerable<ProductDto> Get()
    {
        return _productService.FindAll();
    }

    [HttpGet("prices/latest/{id:int}")]
    public IEnumerable<ProductPriceDto> GetLatestPricesById(int id)
    {
        return _productService.GetLatestPricesById(id);
    }

    [HttpGet("{brand}")]
    public IEnumerable<ProductDto> GetProductsByBrandName(string brand)
    {
        return _productService.GetProductsByBrandName(brand);
    }

    [HttpGet("search")]
    public IEnumerable<ProductDto> SearchProducts([FromQuery(Name = "query")] string query)
    {
        return _productService.Search(query);
    }

}