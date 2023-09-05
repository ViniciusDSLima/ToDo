using API.Request.AssignmentList;
using AutoMapper;
using ClassLibrary1.Interfaces;
using ClassLibrary3.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/v1/AssignmentList")]
public class AssignmentListController : ControllerBase
{
    private readonly IAssignmentListService _assignmentListService;
    private readonly IMapper _mapper;

    public AssignmentListController(IAssignmentListService assignmentListService, IMapper mapper)
    {
        _assignmentListService = assignmentListService;
        _mapper = mapper;
    }


    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastro([FromBody] RegisterAssignmentListRequest registerAssignmentListRequest)
    {
        try
        {
            var assignmentList =
                await _assignmentListService.Create(_mapper.Map<AssignmentListDTO>(registerAssignmentListRequest));

            return Ok("AssignmentList criada com sucesso " + assignmentList);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> Update([FromBody] UpdateAssignmentListRequest updateAssignmentListRequest)
    {
        try
        {
            var assignmentList =
                await _assignmentListService.Update(_mapper.Map<AssignmentListDTO>(updateAssignmentListRequest));
            return Ok("AssignmentList atualizada com sucesso " + assignmentList);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var assignmentList = await _assignmentListService.GetAll();

            if (assignmentList == null)
            {
                return BadRequest("Nenhuma AssignmentList cadastrada no banco de dados");
            }

            return Ok(assignmentList);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var assignmentList = await _assignmentListService.GetById(id);

            if (assignmentList == null)
            {
                return BadRequest("Nao foi encontrada AssignmentList com o id informado");
            }

            return Ok(assignmentList);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("get/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _assignmentListService.Delete(id);

            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest("Nao foi possivel apagar a assignmentList do banco de dados");
        }
    }
}