using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Features.Requests
{
    public class EditFeatureRequest
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ControllerActionName { get; set; }
    }
}
