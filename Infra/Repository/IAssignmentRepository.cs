using ClassLibrary3.Models;

namespace ClassLibrary4.Repository;

public interface IAssignmentRepository : IEntityBaseRepository<Assignment>
{
    Task<Assignment> GetById(int id, int userId);
    Task<List<Assignment>> GetAll(int userId);
    Task<List<Assignment>> SearchByDescription(string description);
    Task Delete(int userId, int assignmentId);
    Task<Assignment> GetByName(string name);
}