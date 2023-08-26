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

    public async Task<AssignmentListDTO> Create(AssignmentListDTO assignmentListDto)
    {
        assignmentListDto.UsuarioId = GetById();
        var assignment = await _assignmentListRepository.Create(_mapper.Map<AssignmentList>(assignmentListDto));
        
        return _mapper.Map<AssignmentListDTO>(assignment);
    }

    public Task<AssignmentListDTO> Update(AssignmentListDTO assignmentListDto)
    {
        throw new NotImplementedException();
    }

    public Task<List<AssignmentListDTO>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<AssignmentListDTO> GetById(int userId)
    {
        throw new NotImplementedException();
    }
    

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}