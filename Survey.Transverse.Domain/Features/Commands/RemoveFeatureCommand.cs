using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Features.Commands
{
    public sealed class RemoveFeatureCommand : ICommand
    {
        public Guid Id { get; }
        public Guid DeletedBy { get; }
        public string Reason { get; }

        public RemoveFeatureCommand(Guid id, Guid deletedBy, string reason)
        {
            Id = id;
            DeletedBy = deletedBy;
            Reason = reason;
        }
    }
}
