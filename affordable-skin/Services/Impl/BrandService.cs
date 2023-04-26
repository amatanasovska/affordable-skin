using affordable_skin.Models;
using affordable_skin.Repositories.Impl;

namespace affordable_skin.Services.Impl;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public IEnumerable<Brand> FindAll()
    {
        return _brandRepository.FindAll();
    }
}