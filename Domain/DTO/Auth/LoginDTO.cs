using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary3.DTO.Auth;

public class LoginDTO
{
    [Required(ErrorMessage = "O email e necessario para fazer o login")]
    [EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = "A senha e necessaria para fazer o login")]
    [PasswordPropertyText]
    public string Password { get; set; }

    public LoginDTO(string email, string password)
    {
        Email = email;
        Password = password;
    }
}