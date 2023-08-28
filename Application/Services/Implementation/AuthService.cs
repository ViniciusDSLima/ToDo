using AutoMapper;
using ClassLibrary1.Interfaces;
using ClassLibrary3.DTO.Auth;
using ClassLibrary4.Repository;

namespace ClassLibrary1.Services.Implementation;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;
    
    public Task<TokenDTO> Register(RegisterDTO registerDto)
    {
        var user = await 
    }

    public Task<TokenDTO> Login(LoginDTO loginDto)
    {
        throw new NotImplementedException();
    }
}