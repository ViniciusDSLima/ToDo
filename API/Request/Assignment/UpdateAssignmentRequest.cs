using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace API.Request.Assignment;

public class UpdateAssignmentRequest
{
    [Required]
    public int Id { get; set; }
    public string Description { get; set; }
    public bool Conclued { get; set; }
    public DateTime ConcluedAt { get; set; }
    public DateTime DeadLine { get; set; }
}