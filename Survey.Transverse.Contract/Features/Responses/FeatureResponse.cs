using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Features.Responses
{
   public class FeatureResponse
    {
        public Guid Id { get; set; }
        public String Label { get; set; }
        public String Description { get; set; }
        public String Controller { get; set; }
        public string ControllerActionName { get; set; }
        public String Action { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
