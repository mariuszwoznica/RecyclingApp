using System;

namespace RecyclingApp.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
    }
}
