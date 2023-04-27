using affordable_skin.Models;

namespace affordable_skin.Services;

public interface ISellerService
{
    IEnumerable<Seller> FindAll();
}