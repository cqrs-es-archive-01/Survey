using System;
using System.Collections.Generic;
using System.Text;
using Survey.Common.Types;

namespace Survey.Transverse.Domain.Users.Commands
{
    public sealed class UnregisterUserCommand: ICommand
    {
        public Guid Id { get;  }
        public string Reason { get;  }
        public Guid By { get; set; }

        public UnregisterUserCommand(Guid id,Guid by,string reason)
        {
            Id = id;
            Reason = reason;
            By = by;
        }
    }
}
