using API.Request;
using AutoMapper;
using ClassLibrary1.Interfaces;
using ClassLibrary3.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Controller]
[Route("ap1/v1/usuarios")]
public class UsuarioController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsuarioController(IUserService userService, IMapper mapper)
    {
        _mapper = mapper;
        _userService = userService;
    }

    [HttpPost]
    [Route("/cadastro")]
    public async Task<IActionResult> Cadastrar([FromBody] RegisterUsuarioRequest registerUsuarioRequest)
    {
        try
        {
            var user = await _userService.Create(_mapper.Map<UsuarioDTO>(registerUsuarioRequest));
            return Ok("Usuario cadastrado com sucesso " + user);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut]
    [Route("/atualizar")]
    public async Task<IActionResult> Atualizar([FromBody] UpdateUsuarioRequest updateUsuarioRequest)
    {
        try
        {
            var newUser = await _userService.Update(_mapper.Map<UsuarioDTO>(updateUsuarioRequest));
            return Ok("Usuario atualizado com sucesso " + newUser);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var users = await _userService.Get();
            return Ok(users);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var user = await _userService.Get(id);
            if (user == null)
            {
                return BadRequest("usuario nao encontrado" + id);
            }

            return Ok("Usuario encontrado " + user);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete]
    [Route("/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _userService.Delete(id);

            return StatusCode(204, "Usuario apagado com sucesso");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

}