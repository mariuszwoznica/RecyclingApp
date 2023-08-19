using System;

namespace RecyclingApp.Application.Exceptions;

public class EntityNotFoundException : Exception //TODO: move or find another solution.
{
    public Guid EntityId { get; }

    public EntityNotFoundException(Guid entityId) : base($"Entity with id {entityId} does not exist.")
        => EntityId = entityId;
}
