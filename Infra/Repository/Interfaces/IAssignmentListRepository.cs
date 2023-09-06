using ClassLibrary3.Models;

namespace ClassLibrary4.Repository;

public interface IAssignmentListRepository : IEntityBaseRepository<AssignmentList>
{
    Task<AssignmentList> GetById(int id, int userId);
    Task<List<AssignmentList>> GetAll(int userId);
    Task Delete(int id);
}