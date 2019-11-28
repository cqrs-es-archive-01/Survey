using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Permissions.Requests
{
   public sealed class EditPermissionRequest
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

        public List<Guid> Features { get; set; }

        public bool DeleteExistingFeatures { get; set; }

        public EditPermissionRequest()
        {
            Features = new List<Guid>();
            DeleteExistingFeatures = false;
        }
    }
}
