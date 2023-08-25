using ClassLibrary3.Models;
using FluentValidation;

namespace ClassLibrary3.Validators;

public class AssignmentValidator : AbstractValidator<Assignment>
{
    public AssignmentValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("A Assignment nao pode ser vazia")
            .NotNull()
            .WithMessage("A Assignment nao pode ser nula");

        RuleFor(x => x.Description)
            .MinimumLength(3)
            .WithMessage("A descricao deve ter no minino 3 caracteres");

        RuleFor(x => x.UsuarioId)
            .GreaterThan(0)
            .WithMessage("O Id do usuario deve ser maior que 0");

        RuleFor(x => x.ConcluedAt)
            .NotEmpty()
            .WithMessage("Nao pode ser vazio")
            .NotNull()
            .WithMessage("Nao pode ser nulo");

        RuleFor(x => x.AssignmentList)
            .NotEmpty()
            .WithMessage("A AssignmentList nao pode ser vazia")
            .NotNull()
            .WithMessage("A AssignmentList nao pode ser nula");

    }
}