using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Users.Commands
{
    public sealed class EditUserCommand : ICommand
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        public List<Guid> Permissions { get; }
        public bool DeleteExistingPermission { get;  }
        public EditUserCommand(Guid id,string firstName,string lastName,string email,
                               List<Guid> permissions=null,bool deleteExisting=false)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Permissions = permissions;
            DeleteExistingPermission = deleteExisting;
        }
    }
}
