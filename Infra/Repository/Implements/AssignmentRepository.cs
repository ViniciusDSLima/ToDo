using System.Data.Entity;
using ClassLibrary3.Models;
using ClassLibrary4.Context;

namespace ClassLibrary4.Repository.Implements;

public class AssignmentRepository :EntityBaseRepository<Assignment>, IAssignmentRepository
{
    private readonly TodoDbContext _context;
    
    public AssignmentRepository(TodoDbContext context) : base(context)
    {
        _context = context;
    }

    public virtual async Task<Assignment> GetById(int id, int userId)
    {
        var assignment = await _context.Set<Assignment>().AsNoTracking()
            .Where(x => x.Id == id && x.UserId == userId).ToListAsync();

        return assignment.FirstOrDefault();
    }

    public virtual async Task<Assignment> GetByDescription(string description)
    {
        var assignment = await _context.Set<Assignment>().AsNoTracking().Where(x => x.Description == description)
            .ToListAsync();

        return assignment.FirstOrDefault();
    }

    public virtual async Task Delete(int id)
    {
         _context.Remove(id);
    }
}