using System.Security.Cryptography;
using ClassLibrary3.Models;

namespace ClassLibrary4.Repository;

public interface IUsuarioRepository : IEntityBaseRepository<Usuario>
{
    Task<Usuario> GetByEmail(string email);
    Task<List<Usuario>> SearchByEmail(string email);
    Task<List<Usuario>> SearchByName(string name);
    Task Delete(int id);
}