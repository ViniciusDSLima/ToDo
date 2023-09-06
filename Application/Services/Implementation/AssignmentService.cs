using AutoMapper;
using ClassLibrary1.Interfaces;
using ClassLibrary3.Models;
using ClassLibrary4.Repository;

namespace ClassLibrary1.Services.Implementation;

public class AssignmentService : IAssignmentService
{

    private readonly IMapper _mapper;
    private readonly IAssignmentRepository  _assignmentRepository;

    public AssignmentService(IMapper mapper, IAssignmentRepository assignmentRepository)
    {
        _mapper = mapper;
        _assignmentRepository = assignmentRepository;
    }

    public async Task<AssignmentDTO> Create(AssignmentDTO assignmentDto)
    {
        var assignmentExists = await _assignmentRepository.GetByDescription(assignmentDto.Description);

        if (assignmentExists != null)
        {
            throw new Exception("Ja existe uma task com essa descricao");
        }

        var assignment = _mapper.Map<Assignment>(assignmentDto);
        assignment.validate();

        var assignmentCreated = await _assignmentRepository.Create(assignment);
        return _mapper.Map<AssignmentDTO>(assignmentCreated);
    }

    public async Task<AssignmentDTO> Update(AssignmentDTO assignmentDto)
    {
        var assignmentExists = await _assignmentRepository.GetById(assignmentDto.Id, assignmentDto.UsuarioId);

        if (assignmentExists == null)
        {
            throw new Exception("Nao existe Task com o id informado");
        }

        var assignment = _mapper.Map<Assignment>(assignmentDto);
        assignment.validate();

        var assignmentUpdate = await _assignmentRepository.Update(assignment);
        assignmentUpdate.validate();

        return _mapper.Map<AssignmentDTO>(assignmentUpdate);
    }

    public async Task<AssignmentDTO> Get(int id)
    {
        var assignment = await _assignmentRepository.Get(id);

        if (assignment == null)
        {
            throw new Exception("Nao existe task com o id informado");
        }

        return _mapper.Map<AssignmentDTO>(assignment);
    }

    public async Task<List<AssignmentDTO>> Get()
    {
        var assignment = await _assignmentRepository.Get();

        if (assignment == null)
        {
            throw new Exception("Nenhuma Task encontrada no banco de dados");
        }

        return _mapper.Map<List<AssignmentDTO>>(assignment);
    }
    
    public async Task Delete(int id)
    {
        var assignment = _assignmentRepository.Get(id);

        if (assignment == null)
        {
            throw new Exception("Nao existe task com o id informado");
        }

        await _assignmentRepository.Delete(id);
    }
    
    public async Task<AssignmentDTO> GetByDescription(string email)
    {
        var assignment = await _assignmentRepository.GetByDescription(email);

        if (assignment ==  null)
        {
            throw new Exception("Nao existe nenhuma task com a descricao informada");
        }

        return _mapper.Map<AssignmentDTO>(assignment);
    }
}