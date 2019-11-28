using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Permissions.Responses
{
   public sealed class PermissionListResponse
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
    }
}
