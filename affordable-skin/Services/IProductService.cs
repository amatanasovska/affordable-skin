using affordable_skin.Models;

namespace affordable_skin.Services;

public interface IProductService
{
    List<Product> FindAll();
    List<ProductPrice> GetLatestPricesById(int id);

    List<Product> GetProductsByBrandName(string brand);
}