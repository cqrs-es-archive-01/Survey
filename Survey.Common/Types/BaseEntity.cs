using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Common.Types
{
    public abstract class BaseEntity : IIdentifiable
    {
        public Guid Id { get; private set; }
        public byte[] Timestamp { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public Guid? CreatedBy { get; protected set; }

        public DateTime UpdatedOn { get; private set; }

        public Guid? DeletedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public bool Deleted { get { return DeletedOn != null; } }
        public string DeleteReason { get; private set; }


        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            SetUpdatedDate();
        }

        protected void MarkAsDeleted(Guid by,string reason)
        {
            this.DeletedBy = by;
            this.DeletedOn = DateTime.Now;
            this.DeleteReason = reason;
        }
        protected virtual void SetUpdatedDate()
            => UpdatedOn = DateTime.UtcNow;
    }
}
