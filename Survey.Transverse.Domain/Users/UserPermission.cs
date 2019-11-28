using Survey.Transverse.Domain.Permissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Users
{
    public class UserPermission
    {
        public DateTime AssociatedOn { get; set; }
        public Guid UserId { get; set; }
        public byte[] Timestamp { get; private set; }

        public virtual User User { get; set; }


        public Guid PermissionId { get; set; }
        public virtual Permission Permission { get; set; }

        public UserPermission()
        {

        }
        public UserPermission(Guid userId, Guid permissionId)
        {
            UserId = userId;
            PermissionId = permissionId;
            AssociatedOn = DateTime.Now;
        }
    }
}
