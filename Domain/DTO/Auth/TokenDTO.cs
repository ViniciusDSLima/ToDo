namespace ClassLibrary3.DTO.Auth;

public class TokenDTO
{
    public string AcessToken { get; set; }
    public double ExpiresIn { get; set; }
    public UserDTO UserDto { get; set; }
}