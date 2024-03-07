namespace Autoshop.Domain
{
    public class Address
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string AddressType { get; set; } // Например, Shipping или Billing

        public virtual Customer Customer { get; set; }
    }
}