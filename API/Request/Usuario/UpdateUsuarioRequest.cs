using System.ComponentModel.DataAnnotations;

namespace API.Request;

public class UpdateUsuarioRequest
{
    [Required]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "Id Nao encontrado")]
    public int AssignmentListId { get; set; }
}