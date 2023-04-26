using affordable_skin.Models;
using affordable_skin.Services;
using affordable_skin.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace affordable_skin.Controllers;

[ApiController]
[Route("[controller]")]
public class BrandController
{
    private readonly ILogger<BrandController> _logger;
    private readonly IBrandService _brandService;

    public BrandController(ILogger<BrandController> logger, IBrandService brandService)
    {
        _logger = logger;
        _brandService = brandService;
    }
    [HttpGet]
    public IEnumerable<Brand> Get()
    {
        return _brandService.FindAll();
    }
}