namespace affordable_skin.Repositories.GenericRepository;

public interface IGenericRepository<T> where T: class
{
    IEnumerable<T> FindAll();
    
}