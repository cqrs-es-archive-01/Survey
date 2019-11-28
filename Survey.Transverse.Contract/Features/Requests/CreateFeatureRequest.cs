using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Features.Requests
{
    public class CreateFeatureRequest
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ControllerActionName { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
