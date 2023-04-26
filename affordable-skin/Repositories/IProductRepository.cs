using affordable_skin.Models;
using affordable_skin.Repositories.GenericRepository;

namespace affordable_skin.Repositories;

public interface IProductRepository : IGenericRepository<Product>
{
    public IEnumerable<ProductPrice> FindLatestPricesByProductId(int id);
    public IEnumerable<Product> GetProductsByBrandName(string brand);
}