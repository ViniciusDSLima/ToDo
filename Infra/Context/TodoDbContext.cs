using ClassLibrary3.Models;
using ClassLibrary4.Map;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary4.Context;

public class TodoDbContext : DbContext
{
    public DbSet<User> Usuarios { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<AssignmentList> AssignmentLists  { get; set; }

    protected TodoDbContext(DbContextOptions<TodoDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    protected TodoDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new AssignmentMap());
        modelBuilder.ApplyConfiguration(new AssignmentListMap());
    }
}