using ClassLibrary3.DTO;

namespace ClassLibrary1.Interfaces;

public interface IAssignmentList
{
    Task<AssignmentListDTO> Create(AssignmentListDTO assignmentListDto);
    Task<AssignmentListDTO> Update(AssignmentListDTO assignmentListDto);
    Task<List<AssignmentListDTO>> Get();
    Task<AssignmentListDTO> Get(int id);
    Task Delete(int id);
}