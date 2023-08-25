using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary3.DTO.Auth;

public class RegisterDTO
{
    [Required(ErrorMessage = "O nome e necessario para se registrar")]
    public string Name { get; set; }
    [Required(ErrorMessage = "O email e necessario para se registrar")]
    [EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = "A senha e necessaria para se registrar")]
    [PasswordPropertyText]
    public string Password { get; set; }
    [Required(ErrorMessage = "Confirmacao de senha e necessaria par se registrar")]
    [PasswordPropertyText]
    [Compare("Password")]
    public string PasswordConfirm { get; set; }
}