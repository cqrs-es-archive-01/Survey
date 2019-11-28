using Survey.Common.Types;
using Survey.Transverse.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survey.Transverse.Domain.Permissions
{
    public class Permission : BaseEntity
    {
        public String Label { get; set; }
        public String Description { get; set; }

        public DateTime? DisabledOn { get; set; }
        public Guid? DisabledBy { get; set; }

        public bool Disabled { get { return DisabledOn != null; } }


        public virtual ICollection<PermissionFeature> PermissionFeatures { get; protected set; }

        public virtual ICollection<UserPermission> UserPermissions { get; protected set; }

        public Permission()
        {
            PermissionFeatures = new List<PermissionFeature>();

        }

        public Permission(string label, string description, Guid createdBy, List<Guid> features = null)
        {
            Label = label;
            Description = label;
            CreatedBy = createdBy;
            if (features != null)
                features.Distinct().ToList().ForEach(a =>
                {
                    if (PermissionFeatures == null)
                        PermissionFeatures = new List<PermissionFeature>();
                    PermissionFeatures.Add(new PermissionFeature(this.Id, a));
                });
        }

        public void Deactivate(Guid disabledby)
        {
            DisabledOn = DateTime.Now;
            DisabledBy = disabledby;
            SetUpdatedDate();
        }

        public void Update(string label, string description, List<Guid> features = null, bool deleteExisting = false)
        {
            UpdateInfo(label, description);
            UpdateFeatures(features, deleteExisting);
        }
        private void UpdateInfo(string label, string description)
        {
            this.Label = label;
            this.Description = description;
            this.SetUpdatedDate();
        }
        private void UpdateFeatures(List<Guid> features, bool deleteExisting = false)
        {
            if (deleteExisting)
                this.PermissionFeatures.Clear();
            features.Distinct().ToList().ForEach(a =>
            {
                if (PermissionFeatures == null)
                    PermissionFeatures = new List<PermissionFeature>();
                PermissionFeatures.Add(new PermissionFeature(this.Id, a));
            });

        }

        public void Remove(Guid by, string reason)
        {
            MarkAsDeleted(by, reason);
        }
    }
}
