using affordable_skin.Data;
using affordable_skin.Models;
using affordable_skin.Repositories.GenericRepository;

namespace affordable_skin.Repositories.Impl;

public class BrandRepository : GenericRepository<Brand>, IBrandRepository
{
    public BrandRepository(ShopContext context) : base(context)
    {
        
    }
}