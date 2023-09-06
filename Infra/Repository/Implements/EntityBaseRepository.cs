using ClassLibrary3.Models;
using ClassLibrary4.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary4.Repository.Implements;

public class EntityBaseRepository<T> : IEntityBaseRepository<T>where T :  EntityBase
{

    private readonly TodoDbContext _context;

    public EntityBaseRepository(TodoDbContext context)
    {
        _context = context;
    }

    public virtual async Task<T> Create(T obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
        return obj;
    }

    public virtual async Task<T> Update(T obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return obj;
    }

    public virtual async Task<List<T>> Get()
    {
        var obj = await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
        return obj;
    }

    public virtual async Task<T> Get(int id)
    {
        var obj = await _context.Set<T>()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .ToListAsync();
        return obj.FirstOrDefault();
    }

}