using RecyclingApp.Domain.Primitives;
using System;

namespace RecyclingApp.Domain.Entities;

public class User : BaseEntity, IAuditableEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime? ModifiedAt { get; }

    private User() { }

    public User(string firstName, string lastName)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
    }

    public static User Create(string firstName, string lastName)
        => new(firstName, lastName);
}
