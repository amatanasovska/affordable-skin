using affordable_skin.Data;
using affordable_skin.Models;
using affordable_skin.Repositories.GenericRepository;

namespace affordable_skin.Repositories.Impl;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ShopContext context) : base(context)
    {
    }
}