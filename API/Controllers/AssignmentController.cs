using API.Request.Assignment;
using AutoMapper;
using ClassLibrary1.Interfaces;
using ClassLibrary3.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/v1/assignments")]
public class AssignmentController : ControllerBase
{
    
    private readonly IAssignmentService _assignmentService;
    private readonly IMapper _mapper;
    
    public AssignmentController(IAssignmentService assignmentService, IMapper mapper)
    {
        _assignmentService = assignmentService;
        _mapper = mapper;
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar([FromBody] RegisterAssignmentRequest registerAssignmentRequest)
    {
        try
        {
            var assignment = await _assignmentService.Create(_mapper.Map<AssignmentDTO>(registerAssignmentRequest));

            if (assignment == null)
            {
                return StatusCode(500, "Task nao criada");
            }

            return Ok("Task criada com sucesso " + assignment);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("atualizar")]
    public async Task<IActionResult> Atualizar([FromBody] UpdateAssignmentRequest updateAssignmentRequest)
    {
        try
        {
            var assignment = await _assignmentService.Update(_mapper.Map<AssignmentDTO>(updateAssignmentRequest));

            return Ok("Task atualizada com sucesso " + assignment);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var assignments = await _assignmentService.Get();
        if (assignments == null)
        {
            return BadRequest("Tasks nao encontradas no banco de dados");
        }

        return Ok(assignments);
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var assignment = await _assignmentService.Get(id);
        if (assignment == null)
        {
            return BadRequest("Nenhuma task com o  id informado");
        }

        return Ok(assignment);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _assignmentService.Delete(id);
            return Ok("Task removida com sucesso");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}