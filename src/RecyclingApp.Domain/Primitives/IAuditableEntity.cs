using System;

namespace RecyclingApp.Domain.Primitives;

public interface IAuditableEntity
{
    DateTime CreatedAt { get; }
    DateTime? ModifiedAt { get; }
}