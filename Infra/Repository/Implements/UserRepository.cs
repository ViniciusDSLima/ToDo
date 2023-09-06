using System.Data.Entity;
using ClassLibrary3.Models;
using ClassLibrary4.Context;

namespace ClassLibrary4.Repository.Implements;

public class UserRepository : EntityBaseRepository<User>, IUserRepository
{
    private readonly TodoDbContext _context;
    
    public UserRepository(TodoDbContext context) : base(context)
    {
        _context = context;
    }

    public virtual async Task<User> GetByEmail(string email)
    {
        var user = await _context.Set<User>().AsNoTracking().Where(x => x.Email == email).ToListAsync();

        return user.FirstOrDefault();
    }

    public virtual async Task<List<User>> SearchByName(string name)
    {
        var users=  await _context.Set<User>().AsNoTracking().Where(x => x.Name.ToLower().Contains(name.ToLower())).ToListAsync();

        return users;
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}