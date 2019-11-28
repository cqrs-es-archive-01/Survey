using Survey.Common.Types;
using Survey.Transverse.Domain.Permissions;
using System;
using System.Collections.Generic;

namespace Survey.Transverse.Domain.Features
{
    public class Feature:BaseEntity
    {
        public String Label { get; set; }
        public String Description { get; set; }
        public String Controller { get; set; }
        public string ControllerActionName { get; set; }
        public String Action { get; set; }
        public DateTime? DisabledOn { get; set; }
        public Guid? DisabledBy { get; set; }

        public bool Disabled { get { return DisabledOn != null; } }

        public virtual ICollection<PermissionFeature> PermissionFeatures { get; protected set; }


        public Feature()
        {

        }
        public Feature(string label, string description, string action, string controller,
                                 string controllerActionNmae, Guid createdBy)
        {
            Label = label;
            Description = description;
            Action = action;
            Controller = controller;
            ControllerActionName = controllerActionNmae;
            CreatedBy = createdBy;
        }

        public void Deactivate(Guid disabledby)
        {
            DisabledOn = DateTime.Now;
            DisabledBy = disabledby;
            SetUpdatedDate();
        }

        public void UpdateInfo(string label, string description, string action, string controller,
                                 string controllerActionName)
        {
            this.Label = label;
            this.Description = description;
            this.Action = action;
            this.Controller = controller;
            this.ControllerActionName = controllerActionName;
            this.SetUpdatedDate();
        }

        public void Remove(Guid by,string reason)
        {
            MarkAsDeleted(by, reason);
        }
    }
}
