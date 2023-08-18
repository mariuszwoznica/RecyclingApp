using System;

namespace RecyclingApp.Domain.Primitives;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
}
