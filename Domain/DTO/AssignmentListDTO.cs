

public class AssignmentListDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int UsuarioId { get; set; }

    public AssignmentListDTO()
    {
    }

    public AssignmentListDTO(int id, string name, int usuarioId)
    {
        Id = id;
        Name = name;
        UsuarioId = usuarioId;
    }
}