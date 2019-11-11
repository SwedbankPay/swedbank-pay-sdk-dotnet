using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Sample.AspNetCore3.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        public string PaymentOrderLink { get; set; }
        public string PaymentLink { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
    }
}