using affordable_skin.Models;
using affordable_skin.Repositories;

namespace affordable_skin.Services.Impl;

public class SellerService : ISellerService
{
    private readonly ISellerRepository _sellerRepository;

    public SellerService(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }
    public IEnumerable<Seller> FindAll()
    {
        return _sellerRepository.FindAll();
    }
}