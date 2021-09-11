using System;
using System.Collections.Generic;

#nullable disable

namespace Shoe.Models.DBModels
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string ReceiveName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string AddressDelivery { get; set; }
        public int? TotalPrice { get; set; }
        public int? Phone { get; set; }
        public int? Payment { get; set; }
        public string Message { get; set; }
        public int? Paid { get; set; }
        public int? Status { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
