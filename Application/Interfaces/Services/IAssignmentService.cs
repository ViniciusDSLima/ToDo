using ClassLibrary3.DTO;

namespace ClassLibrary1.Interfaces;

public interface IAssignmentService
{
    Task<AssignmentDTO> Create(AssignmentDTO assignmentDto);
    Task<AssignmentDTO> Update(AssignmentListDTO assignmentDto);
    Task<AssignmentDTO> Get(int id);
    Task<List<AssignmentDTO>> Get();
    Task Delete(int id);
}