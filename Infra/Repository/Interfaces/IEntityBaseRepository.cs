using ClassLibrary3.Models;

namespace ClassLibrary4.Repository;

public interface IEntityBaseRepository<T> where T : EntityBase
{
    Task<T> Create(T obj);
    Task<T> Update(T obj);
    Task<List<T>> Get();
    Task<T> Get(int id);
}