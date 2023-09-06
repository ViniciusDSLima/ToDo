using ClassLibrary3.Models;

namespace ClassLibrary4.Repository;

public interface IAssignmentRepository : IEntityBaseRepository<Assignment>
{
    Task<Assignment> GetById(int id, int userId);
    Task<Assignment> GetByDescription(string description);
    Task Delete(int id);
}