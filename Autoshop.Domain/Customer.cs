using System.Collections.Generic;

namespace Autoshop.Domain
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }

}