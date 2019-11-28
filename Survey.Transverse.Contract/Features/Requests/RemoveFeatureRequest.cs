using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Features.Requests
{
   public  class RemoveFeatureRequest
    {
        public string Reason { get; set; }
        public Guid DeletedBy { get; set; }
    }
}
