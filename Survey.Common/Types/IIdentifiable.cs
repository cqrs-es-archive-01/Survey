using System;

namespace Survey.Common.Types
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}