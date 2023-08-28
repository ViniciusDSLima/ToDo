using System.Collections.ObjectModel;
using ClassLibrary3.Validators;

namespace ClassLibrary3.Models;

public class User : EntityBase
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public virtual Collection<Assignment> Assignments { get; set; } = new();
    public virtual Collection<AssignmentList> AssignmentsLists { get; set; } = new();

    public User()
    {
        
    }

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
        _errors = new List<string>();
    }


    public override bool validate()
    {
        var validator = new UsuarioValidator();
        var validation = validator.Validate(this);

        if (validation.IsValid)
        {
            return true;
        }
        else
        {
            foreach (var error in validation.Errors)
            {
                _errors.Add(error.ErrorMessage);
            }

            throw new Exception("campos invalidos " + _errors);
        }
    }


    public void ChangeName(string name)
    {
        this.Name = name;
        validate();
    }
    
    
    public void ChangeEmail(string email)
    {
        this.Email = email;
        validate();
    }
    
    
    public void ChangePassword(string password)
    {
        this.Password = password;
        validate();
    }
}