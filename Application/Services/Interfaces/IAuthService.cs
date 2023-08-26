using ClassLibrary3.DTO.Auth;

namespace ClassLibrary1.Interfaces;

public interface IAuthService
{
    Task<TokenDTO> Register(RegisterDTO registerDto);
    Task<TokenDTO> Login(LoginDTO loginDto);
}