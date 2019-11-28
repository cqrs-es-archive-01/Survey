using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Permissions.Commands
{
    public sealed class RemovePermissionCommand : ICommand
    {
        public Guid Id { get; }
        public string Reason { get; }
        public Guid By { get; }
        public RemovePermissionCommand(Guid id, Guid by,string reason)
        {
            Id = id;
            Reason = reason;
            By = by;
        }
    }
}
