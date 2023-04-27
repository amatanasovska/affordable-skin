using affordable_skin.Models;
using affordable_skin.Services;
using Microsoft.AspNetCore.Mvc;

namespace affordable_skin.Controllers;

[ApiController]
[Route("[controller]")]
public class SellersController
{
    private readonly ILogger<SellersController> _logger;
    private readonly ISellerService _sellerService;
    public SellersController(ILogger<SellersController> logger,ISellerService sellerService)
    {
        _logger = logger;
        _sellerService = sellerService;
    }
    [HttpGet]
    public IEnumerable<Seller> Get()
    {
        return _sellerService.FindAll();
    }

}