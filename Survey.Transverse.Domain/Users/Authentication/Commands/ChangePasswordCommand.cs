using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Users.Authentication.Commands
{
    public sealed class ChangePasswordCommand:ICommand
    {
        public Guid Id { get;  }
        public string  OldPassword { get;  }
        public string NewPassword { get;  }

        public ChangePasswordCommand(Guid id,string oldPassword,string newPassword)
        {
            Id = id;
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }
    }
}
