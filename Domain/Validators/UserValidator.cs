using ClassLibrary3.Models;
using FluentValidation;

namespace ClassLibrary3.Validators;

public class UserValidator : AbstractValidator<User>
{

    public UserValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("O usuario nao pode ser vazio");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("O Nome nao pode ser vazio")
            .NotNull()
            .WithMessage("O nome nao pode ser nullo")
            .MinimumLength(3)
            .WithMessage("O nome tem no minimo 3 caracteres")
            .MaximumLength(255)
            .WithMessage("O nome tem no maximo 255 caracteres");
        
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("O Email nao pode ser vazio")
            .NotNull()
            .WithMessage("O Email nao pode ser nullo")
            .MinimumLength(13)
            .WithMessage("O Email tem no minimo 13 caracteres")
            .MaximumLength(30)
            .WithMessage("O Email tem no maximo 30 caracteres");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("A senha nao pode ser vazio")
            .NotNull()
            .WithMessage("A senha nao pode ser nullo")
            .MinimumLength(8)
            .WithMessage("A senha tem no minimo 8 caracteres")
            .MaximumLength(20)
            .WithMessage("A senha tem no maximo 20 caracteres");

    }
    
}