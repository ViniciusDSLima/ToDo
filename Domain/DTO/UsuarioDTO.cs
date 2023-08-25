namespace ClassLibrary3.DTO;

public class UsuarioDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UsuarioDTO()
    {
    }

    public UsuarioDTO(int id, string name, string email, string password)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
    }
}