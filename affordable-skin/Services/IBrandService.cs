using affordable_skin.Models;

namespace affordable_skin.Services;

public interface IBrandService
{
   IEnumerable<Brand> FindAll();
}