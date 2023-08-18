using RecyclingApp.Domain.Entities.Orders;
using RecyclingApp.Domain.Primitives;
using System;
using System.Collections.Generic;

namespace RecyclingApp.Domain.Entities;

public class User : BaseEntity, IAuditableEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime? ModifiedAt { get; }

    private User() { }

    public User(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public static User Create(string firstName, string lastName)
        => new(Guid.NewGuid(), firstName, lastName);
}
