using affordable_skin.Models;
using affordable_skin.Models.dto;

namespace affordable_skin.Services;

public interface IProductService
{
    List<ProductDto> FindAll();
    List<ProductPriceDto> GetLatestPricesById(int id);

    List<ProductDto> GetProductsByBrandName(string brand);
}