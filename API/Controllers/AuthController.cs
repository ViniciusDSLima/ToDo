using System.ComponentModel.DataAnnotations;
using ClassLibrary1.Interfaces;
using ClassLibrary3.DTO.Auth;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Controller]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    public readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [Route("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
    {
        try
        {
            var register = await _authService.Register(registerDto);
            return Ok("usuario registrado com sucesso");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
    {
        var user = new LoginDTO(
            email: loginDto.Email,
            password: loginDto.Password);

        var token = await _authService.Login(user);

        return Ok(token);
    }
}