using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Permissions.Requests
{
    public class DeactivatePermissionRequest
    {
        public Guid DeletedBy { get; set; }
    }
}
