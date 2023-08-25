using System.ComponentModel.DataAnnotations;

namespace API.Request;

public class RegisterUsuarioRequest
{
    [Required(ErrorMessage = "O nome e obrigatorio")]
    [MinLength(3, ErrorMessage = "O nome tem ao menos 3 caracteres")]
    [MaxLength(255, ErrorMessage = "O nome tem ao maximo 255 caracteres")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "O email e obrigatorio")]
    [MinLength(13, ErrorMessage = "O email tem ao menos 13 caracteres")]
    [MaxLength(30, ErrorMessage = "O email tem ao maximo 30 caracteres")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "A senha e obrigatoria")]
    [MinLength(8, ErrorMessage = "A senha tem ao menos 8 caracteres")]
    [MaxLength(20, ErrorMessage = "A senha tem ao maximo 20 caracteres")]
    public string Password { get; set; }
}

