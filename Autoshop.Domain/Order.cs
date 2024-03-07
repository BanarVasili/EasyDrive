using System;
using System.Collections.Generic;

namespace Autoshop.Domain
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}