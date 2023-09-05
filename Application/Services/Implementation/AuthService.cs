// using AutoMapper;
// using ClassLibrary1.Interfaces;
// using ClassLibrary3.DTO.Auth;
// using ClassLibrary3.Models;
// using ClassLibrary4.Repository;
// using Microsoft.AspNetCore.Identity;
//
// namespace ClassLibrary1.Services.Implementation;
//
// public class AuthService : IAuthService
// {
//     private readonly IUserRepository _userRepository;
//     private readonly IPasswordHasher<User> _passwordHasher;
//
//
//     public AuthService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
//     {
//         _userRepository = userRepository;
//         _passwordHasher = passwordHasher;
//     }
//
//     public async Task<TokenDTO> Register(RegisterDTO registerDto)
//     {
//         var userExists = await _userRepository.GetByEmail(registerDto.Email);
//         if (userExists != null)
//         {
//             throw new Exception("Usuario ja cadastrado");
//         }
//
//         var user = new User(
//             name: registerDto.Name,
//             email: registerDto.Email,
//             password: "");
//         
//         user.SetPassword(_passwordHasher.HashPassword(user, registerDto.Password));
//
//         await _userRepository.Create(user);
//
//         return GenerateToken(user);
//     }
//
//     public async Task<TokenDTO> Login(LoginDTO loginDto)
//     {
//         var user = await _userRepository.GetByEmail(loginDto.Email);
//
//         if (user == null)
//         {
//             throw new Exception("Usuario nao cadastrado");
//         }
//
//         var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginDto.Password);
//
//         if (result == PasswordVerificationResult.Failed)
//         {
//             throw new Exception("Usuario e/ou senha incorretos");
//         }
//
//         return GenerateToken(user);
//     }
//     
// }