using affordable_skin.Data;

namespace affordable_skin.Repositories.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T:class
{
    protected readonly ShopContext _context;

    public GenericRepository(ShopContext context)
    {
        _context = context;
    }
    public IEnumerable<T> FindAll()
    {
        return _context.Set<T>().ToList();
    }
}