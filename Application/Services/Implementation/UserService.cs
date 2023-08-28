using AutoMapper;
using ClassLibrary1.Interfaces;
using ClassLibrary3.DTO;
using ClassLibrary3.Models;
using ClassLibrary4.Repository;

namespace ClassLibrary1.Services.Implementation;

public class UserService : IUserService
{

    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserDTO> Create(UserDTO userDto)
    {
        var user = _userRepository.GetByEmail(userDto.Email);
        if (user != null)
        {
            throw new Exception("Usuario com email ja existente");
        }

        var userCreate = _mapper.Map<User>(userDto);
        userCreate.validate();

        var userCreated = await _userRepository.Create(userCreate);
        return _mapper.Map<UserDTO>(userCreated);
    }

    public async Task<UserDTO> Update(UserDTO userDto)
    {
        var user = _userRepository.Get(userDto.Id);
        if (user == null)
        {
            throw new Exception("Nao existe nenhum usuario com o id informado");
        }

        var userUpdate = _mapper.Map<User>(userDto);
        userUpdate.validate();

        var userUpdated = await _userRepository.Update(userUpdate);
        return _mapper.Map<UserDTO>(userUpdated);
    }

    public async Task<List<UserDTO>> Get()
    {
        var users = await _userRepository.Get();

        if (users == null)
        {
            throw new Exception("Nao foi cadastrado nenhum usuario no bano de dados");
        }

        return _mapper.Map<List<UserDTO>>(users);
    }

    public async Task<UserDTO> Get(int id)
    {
        var user = await _userRepository.Get(id);

        if (user == null)
        {
            throw new Exception("Nao existe usuario com o id informado");
        }
        return _mapper.Map<UserDTO>(user);
    }

    public async Task Delete(int id)
    {
        var user = await _userRepository.Get(id);

        if (user == null)
        {
            throw new Exception("Nao existe usuario com o id informado");
        }

        await _userRepository.Delete(id);
    }
}