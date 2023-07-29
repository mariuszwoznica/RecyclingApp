using RecyclingApp.Domain.Common;
using RecyclingApp.Domain.Model.Orders;
using System.Collections.Generic;

namespace RecyclingApp.Domain.Model;

public class User : BaseEntity, IAuditable
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public ICollection<Order> Orders { get; private set; }

    private User() { }

    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static User Create(string firstName, string lastName)
        => new User(firstName, lastName);

}
