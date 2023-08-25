using ClassLibrary3.DTO;

namespace ClassLibrary1.Interfaces;

public interface IUserService
{
    Task<UserDTO> Create(UserDTO userDto);
    Task<UserDTO> Update(UserDTO userDto);
    Task<List<UserDTO>> Get();
    Task<UserDTO> Get(int id);
    Task Delete(int id);
}