using Survey.Transverse.Domain.Features;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Permissions
{
    public class PermissionFeature
    {
        public Guid PermissionId { get; set; }
        public Guid FeatureId { get; set; }
        public byte[] Timestamp { get; private set; }

        public DateTime AssociatedOn { get; set; }
        public virtual Feature Feature { get; set; }
        public virtual Permission Permission { get; set; }

        public PermissionFeature(Guid permissionId, Guid featureId)
        {
            PermissionId = permissionId;
            FeatureId = featureId;
            AssociatedOn = DateTime.Now;
        }
        public PermissionFeature()
        {

        }
    }
}
