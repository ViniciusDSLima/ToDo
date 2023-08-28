using ClassLibrary3.DTO;

namespace ClassLibrary1.Interfaces;

public interface IAssignmentListService
{
    Task<AssignmentListDTO> Create(AssignmentListDTO assignmentListDto);
    Task<AssignmentListDTO> Update(AssignmentListDTO assignmentListDto);
    Task<List<AssignmentListDTO>> GetAll();
    Task<AssignmentListDTO> GetById(int id);
    Task Delete(int id);
}