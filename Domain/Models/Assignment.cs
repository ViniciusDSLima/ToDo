using System.Text;
using ClassLibrary3.Validators;

namespace ClassLibrary3.Models;

public class Assignment : EntityBase
{
    public int UsuarioId { get; set; }
    public string Description { get; set; }
    public bool Conclued { get; set; }
    public DateTime? ConcluedAt { get; set; }
    public DateTime DeadLine { get; set; }
    public int AssignmentListId { get; set; }

    public virtual Usuario Usuario { get; set; } 
    public virtual AssignmentList AssignmentList{ get; set; }

    public Assignment()
    {
    }

    public Assignment(int usuarioId, string description, bool conclued, DateTime concluedAt, DateTime deadLine, int assignmentListId, AssignmentList assignmentList)
    {
        UsuarioId = usuarioId;
        Description = description;
        Conclued = conclued;
        ConcluedAt = concluedAt;
        DeadLine = deadLine;
        AssignmentListId = assignmentListId;
        AssignmentList = assignmentList;
    }

    public override bool validate()
    {
        var validator = new AssignmentValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
            {
                _errors.Add(error.ErrorMessage);
            }

            throw new Exception("Campos invalidos " + _errors);
        }

        return true;
    }


    public void IsConclued()
    {
        ConcluedAt = DateTime.Now;
        Conclued = true;
    }
    
    
    public void IsNotConclued()
    {
        ConcluedAt = null;
        Conclued = false;
    }
    
    public void ChangeDescription(string description)
    {
       this.Description = description ;
        validate();
    }
    
    
    public void ChangeDeadLine(DateTime date)
    {
        this.DeadLine = date ;
        validate();
    }
}