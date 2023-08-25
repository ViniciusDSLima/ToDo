

public class AssignmentDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int UsuarioId { get; set; }
    public int AssignmentListId { get; set; }
    public bool Conclued { get; set; }
    public DateTime ConcluedAt { get; set; }
    public DateTime DeadLine { get; set; }

    public AssignmentDTO()
    {
    }

    public AssignmentDTO( string name, string description, int usuarioId, int assignmentListId, bool conclued, DateTime concluedAt, DateTime deadLine)
    {
        Name = name;
        Description = description;
        UsuarioId = usuarioId;
        AssignmentListId = assignmentListId;
        Conclued = conclued;
        ConcluedAt = concluedAt;
        DeadLine = deadLine;
    }
}