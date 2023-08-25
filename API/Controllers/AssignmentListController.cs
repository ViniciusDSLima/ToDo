using API.Request.AssignmentList;
using AutoMapper;
using ClassLibrary1.Interfaces;
using ClassLibrary3.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Controller]
[Route("api/v1/AssignmentList")]
public class AssignmentListController : ControllerBase
{
    private readonly IAssignmentService _assignmentService;
    private readonly IMapper _mapper;

    public AssignmentListController(IAssignmentService assignmentService, IMapper mapper)
    {
        _assignmentService = assignmentService;
        _mapper = mapper;
    }


    [HttpPost]
    [Route("/cadastrar")]
    public async Task<IActionResult> Cadastro([FromBody] RegisterAssignmentListRequest registerAssignmentListRequest)
    {
        try
        {
            var assignmentList =
                await _assignmentService.Create(_mapper.Map<AssignmentListDTO>(registerAssignmentListRequest));

            return Ok("AssignmentList criada com sucesso " + assignmentList);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Route("/atualizar")]
    public async Task<IActionResult> Update([FromBody] UpdateAssignmentListRequest updateAssignmentListRequest)
    {
        try
        {
            var assignmentList =
                await _assignmentService.Update(_mapper.Map<AssignmentListDTO>(updateAssignmentListRequest));
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
            var assignmentList = await _assignmentService.Get();

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

    [HttpGet]
    [Route("/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var assignmentList = await _assignmentService.Get(id);

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
}