using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Permissions.Commands
{
    public sealed class DeactivatePermissionCommand : ICommand
    {
        public Guid Id { get; }
        public Guid DisabledBy { get; }

        public DeactivatePermissionCommand(Guid id,Guid disabledBy)
        {
            Id = id;
            DisabledBy = disabledBy;
        }
    }
}
