using ClassLibrary3.Validators;

namespace ClassLibrary3.Models;

public class AssignmentList : EntityBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int UsuarioId { get; set; }

    public virtual Usuario Usuario { get; set; }
    public virtual List<Assignment> Assignments { get; set; }

    public AssignmentList()
    {
    }

    public AssignmentList(int id, string name, int usuarioId)
    {
        Id = id;
        Name = name;
        UsuarioId = usuarioId;
        _errors = new List<string>();
    }

    public override bool validate()
    {
        var validator = new AssignmentListValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
            {
                _errors.Add(error.ErrorMessage);
            }
            
            throw new Exception("campos invalidos " + _errors);
        }

        return true;
    }
}
