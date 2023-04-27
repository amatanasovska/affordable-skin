using affordable_skin.Data;
using affordable_skin.Models;
using affordable_skin.Repositories.GenericRepository;

namespace affordable_skin.Repositories.Impl;

public class SellerRepository : GenericRepository<Seller>, ISellerRepository
{
    public SellerRepository(ShopContext context) : base(context)
    {
        
    }
}