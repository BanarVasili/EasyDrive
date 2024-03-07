namespace Autoshop.Domain
{
    public class Car
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}