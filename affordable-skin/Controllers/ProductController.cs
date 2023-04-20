using affordable_skin.Models;
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
    public IEnumerable<Product> Get()
    {
        return _productService.FindAll();
    }
    
}