using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Users.Authentication.Commands
{
    public sealed class SignOutCommand:ICommand
    {
        public Guid Id { get;  }
        public SignOutCommand(Guid id)
        {
            Id = id;
        }
    }
}
