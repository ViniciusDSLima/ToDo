using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace API.Request.AssignmentList;

public class RegisterAssignmentListRequest
{
    [Required(ErrorMessage = "A descricao nao pode ser nula")]
    [MinLength(3, ErrorMessage = "A descricao deve ter no minimo 3 caracteres")]
    [MaxLength(255, ErrorMessage = "A descricao tem no maximo 255 caracteres")]
    public string Description { get; set; }
}