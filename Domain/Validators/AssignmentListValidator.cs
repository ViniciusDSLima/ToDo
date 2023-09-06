using System.Data;
using ClassLibrary3.Models;
using FluentValidation;

namespace ClassLibrary3.Validators;

public class AssignmentListValidator : AbstractValidator<AssignmentList>
{
    public AssignmentListValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("A entidade nao pode ser vazia")
            .NotNull()
            .WithMessage("A entidade nao pode ser nula");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("O nome nao pode ser vazio")
            .NotNull()
            .WithMessage("O nome nao pode ser nulo")
            .MinimumLength(3)
            .WithMessage("O nome tem de ter no minimo 3 caracteres")
            .MaximumLength(255)
            .WithMessage("O nome te de ter no maximo 255 caracteres");

        RuleFor(x => x.UserId)
            .NotNull()
            .WithMessage("O UsuarioId nao pode ser nulo");
    }
}