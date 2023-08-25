using FluentValidation.Validators;

namespace ClassLibrary3.Models;

public abstract class EntityBase
{
    public int Id { get; set; }
    internal List<string> _errors;
    public IReadOnlyCollection<string> Errors => _errors;

    public abstract bool validate();
}