using System.ComponentModel.DataAnnotations;

namespace API.Request.Assignment;

public class RegisterAssignmentRequest
{
    [Required(ErrorMessage = "A descricao nao pode estar vazia")]
    [MinLength(3, ErrorMessage = "A descricao precisa ter no minimo 3 caracteres")]
    [MaxLength(255, ErrorMessage = "A descricao tem no maximo 255 caracteres")]
    public string Description { get; set; }
    [Required(ErrorMessage = "A descricao nao pode estar vazia")]
    public int AssignmentlistId { get; set; }
    
    public bool Conclued { get; set; }
    public DateTime? ConcluedAt { get; set; }
    public DateTime? DeadLine { get; set; }
}