using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Permissions.Requests
{
    public sealed class RemovePermissionRequest
    {
        public string Reason { get; set; }
        public Guid DeletedBy { get; set; }
    }
}
