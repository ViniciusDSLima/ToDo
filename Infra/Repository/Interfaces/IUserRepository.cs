using System.Security.Cryptography;
using ClassLibrary3.Models;

namespace ClassLibrary4.Repository;

public interface IUserRepository : IEntityBaseRepository<User>
{
    Task<User> GetByEmail(string email);
    Task<List<User>> SearchByName(string name);
    Task Delete(int id);
}