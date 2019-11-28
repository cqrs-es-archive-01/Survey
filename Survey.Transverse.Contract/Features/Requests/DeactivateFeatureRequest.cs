using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Features.Requests
{
    public class DeactivateFeatureRequest
    {
        public Guid DeletedBy { get; set; }
    }
}
