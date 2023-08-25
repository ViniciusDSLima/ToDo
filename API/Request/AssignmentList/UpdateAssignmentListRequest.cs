using System.ComponentModel.DataAnnotations;
using ClassLibrary3.Models;

namespace API.Request.AssignmentList;

public class UpdateAssignmentListRequest
{
    [Required(ErrorMessage = "O id e necessario para atualizar a TaskList")]
    public int Id { get; set; }

    [Required(ErrorMessage = "A descricao da list nao pode ser vazia")]
    [MinLength(3, ErrorMessage = "A descricao precisa ter no minimo 3 caracteres")]
    [MaxLength(255, ErrorMessage = "A descricao precisa ter no minimo 255 caracteres")]
    public string Description { get; set; }
}