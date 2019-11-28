using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Permissions.Requests
{
    public sealed class CreatePermissionRequest
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public Guid CreatedBy { get; set; }

        public List<Guid> Features { get; set; }

        public CreatePermissionRequest()
        {
            Features = new List<Guid>();
        }
    }
}
