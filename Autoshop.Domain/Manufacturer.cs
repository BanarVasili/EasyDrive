using System.Collections.Generic;

namespace Autoshop.Domain
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }

        // Navigation property
        public virtual ICollection<Car> Cars { get; set; }
        // Другие свойства
    }
}