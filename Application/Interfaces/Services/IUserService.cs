using ClassLibrary3.DTO;

namespace ClassLibrary1.Interfaces;

public interface IUserService
{
    Task<UsuarioDTO> Create(UsuarioDTO usuarioDto);
    Task<UsuarioDTO> Update(UsuarioDTO usuarioDto);
    Task<List<UsuarioDTO>> Get();
    Task<UsuarioDTO> Get(int id);
    Task Delete(int id);
}