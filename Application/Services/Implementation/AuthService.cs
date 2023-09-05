using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using ClassLibrary1.Interfaces;
using ClassLibrary3.DTO;
using ClassLibrary3.DTO.Auth;
using ClassLibrary3.Models;
using ClassLibrary4;
using ClassLibrary4.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace ClassLibrary1.Services.Implementation;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;


    public AuthService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<TokenDTO> Register(RegisterDTO registerDto)
    {
        var userExists = await _userRepository.GetByEmail(registerDto.Email);
        if (userExists != null)
        {
            throw new Exception("Usuario ja cadastrado");
        }

        var user = new User(
            name: registerDto.Name,
            email: registerDto.Email,
            password: "");
        
        user.SetPassword(_passwordHasher.HashPassword(user, registerDto.Password));

        await _userRepository.Create(user);

        return GenerateToken(user);
    }

    public async Task<TokenDTO> Login(LoginDTO loginDto)
    {
        var user = await _userRepository.GetByEmail(loginDto.Email);

        if (user == null)
        {
            throw new Exception("Usuario nao cadastrado");
        }

        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginDto.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            throw new Exception("Usuario e/ou senha incorretos");
        }

        return GenerateToken(user);
    }
    
    
    private  TokenDTO GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new("id", user.Id.ToString()),
            new(JwtRegisteredClaimNames.Name, user.Name),
            new(JwtRegisteredClaimNames.Email, user.Email)
        };

        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaims(claims);

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = DateTime.Now.AddHours(3),
            
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.Secret)),
                SecurityAlgorithms.HmacSha256)
        });

        var tokenSecret = tokenHandler.WriteToken(token);


        return new TokenDTO
        {
            AcessToken = tokenSecret,
            ExpiresIn = TimeSpan.FromHours(Settings.TokenExpiration).TotalSeconds,

            UserDto = new UserDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            }
        };
    }
    
}