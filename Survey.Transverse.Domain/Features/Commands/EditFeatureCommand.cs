using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Features.Commands
{
    public sealed class EditFeatureCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Label { get; }
        public string Description { get; }
        public string Action { get; }
        public string Controller { get; }
        public string ControllerActionName { get; }
        public EditFeatureCommand(Guid id, string label, string description, string action,
                                        string controller, string controllerActionName)
        {
            Id = id;
            Label = label;
            Description = description;
            Action = action;
            Controller = controller;
            ControllerActionName = controllerActionName;
        }
    }
}
