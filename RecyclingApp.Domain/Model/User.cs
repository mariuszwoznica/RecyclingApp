using RecyclingApp.Domain.Common;
using RecyclingApp.Domain.Model.Orders;
using System;
using System.Collections.Generic;

namespace RecyclingApp.Domain.Model;

public class User : BaseEntity, IAuditable
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public ICollection<Order> Orders { get; private set; }

    private User() { }

    public User(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public static User Create(string firstName, string lastName)
        => new User(Guid.NewGuid(), firstName, lastName);
}
