using AutoMapper;
using ClassLibrary1.Interfaces;
using ClassLibrary3.Models;
using ClassLibrary4.Repository;
using Microsoft.AspNetCore.Http;

namespace ClassLibrary1.Services.Implementation;

public class AssignmentListService : IAssignmentListService
{

    private readonly IMapper _mapper;
    private readonly IAssignmentListRepository _assignmentListRepository;
    private readonly IHttpContextAccessor _httpContextAcessor;

    public AssignmentListService(IMapper mapper, IAssignmentListRepository assignmentListRepository, IHttpContextAccessor httpContextAcessor)
    {
        _mapper = mapper;
        _assignmentListRepository = assignmentListRepository;
        _httpContextAcessor = httpContextAcessor;
    }

    public int GetUsuarioId()
    {
        var claim = _httpContextAcessor.HttpContext.User.Claims.FirstOrDefault(u => u.Type == "Id");
        if (claim == null)
        {
            throw new Exception("Claim nula");
        }

        return int.Parse(claim.Value);
    }

    public async Task<AssignmentListDTO> Create(AssignmentListDTO assignmentListDto)
    {
        assignmentListDto.UsuarioId = GetUsuarioId();
        var assignmentList = await _assignmentListRepository.Create(_mapper.Map<AssignmentList>(assignmentListDto));
        return _mapper.Map<AssignmentListDTO>(assignmentList);
    }

    public async Task<AssignmentListDTO> Update(AssignmentListDTO assignmentListDto)
    {
        var assignmentListExists = await _assignmentListRepository.GetById(assignmentListDto.Id, GetUsuarioId());

        if (assignmentListExists == null)
        {
            throw new Exception("Nao existe Lista com o id informado");
        }

        var assignmentList = _mapper.Map<AssignmentList>(assignmentListDto);
        assignmentList.UsuarioId = GetUsuarioId();
        assignmentList.validate();

        var assignmentListUpdated = await _assignmentListRepository.Update(assignmentList);

        return _mapper.Map<AssignmentListDTO>(assignmentListUpdated);
    }

    public async Task<List<AssignmentListDTO>> GetAll()
    {
        var assignmentList = await _assignmentListRepository.GetAll(GetUsuarioId());
        
        return _mapper.Map<List<AssignmentListDTO>>(assignmentList);
    }

    public async Task<AssignmentListDTO> GetById(int id)
    {
        var assignmentList = await _assignmentListRepository.GetById(id, GetUsuarioId());

        if (assignmentList == null)
        {
            throw new Exception("AssingmentList nao existente com o Id informado");
        }

        return _mapper.Map<AssignmentListDTO>(assignmentList);
    }
    

    public async Task Delete(int id)
    {
        var assignemntList = await _assignmentListRepository.GetById(id, GetUsuarioId());

        if (assignemntList == null)
        {
            throw new Exception("Nao exite assignmentList existente com o id informado");
        }
        
        await _assignmentListRepository.Delete(id);
    }
}