using RecyclingApp.Domain.Common;
using System.Collections.Generic;

namespace RecyclingApp.Domain.Model
{
    public class User : BaseEntity, IAuditable
    {
        private User() { }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        private readonly List<Order> _orders = new List<Order>();

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IEnumerable<Order> Orders => _orders.AsReadOnly();

        public static User Create(string firstName, string lastName)
        {
            return new User(firstName, lastName);
        }

    }
}
