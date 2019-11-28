using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Features.Commands
{
    public sealed class CreateFeatureCommand : ICommand
    {
        public string Label { get; }
        public string Description { get; }
        public string Action { get; }
        public string Controller { get; }
        public string ControllerActionName { get; }
        public Guid CreatedBy { get; }
        public CreateFeatureCommand(string label, string description, string action, string controller,
                                 string controllerActionNmae, Guid createdBy)
        {
            Label = label;
            Description = description;
            Action = action;
            Controller = controller;
            ControllerActionName = controllerActionNmae;
            CreatedBy = createdBy;
        }
    }
}
