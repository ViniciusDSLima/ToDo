using System.Data.Entity;
using ClassLibrary3.Models;
using ClassLibrary4.Context;

namespace ClassLibrary4.Repository.Implements;

public class AssignmentListRepository : EntityBaseRepository<AssignmentList>, IAssignmentListRepository
{
    private readonly TodoDbContext _context;
    public AssignmentListRepository(TodoDbContext context) : base(context)
    {
        _context = context;
    }

    public virtual async Task<AssignmentList> GetById(int id, int userId)
    {
        var assignmentList =  _context.Set<AssignmentList>().AsNoTracking().FirstOrDefault(
            x => x.Id == id && x.UserId == userId);
        
        return assignmentList;
    }

    public virtual async Task<List<AssignmentList>> GetAll(int userId)
    {
        var assignmentLists =
            await _context.Set<AssignmentList>().AsNoTracking().Where(x => x.Id == userId).ToListAsync();

        return assignmentLists;
    }

    public virtual async Task Delete(int id)
    {
        _context.Remove(id);
    }
}