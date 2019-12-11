using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Sample.AspNetCore.Models
{
    public class Order
    {
        [BindNever] public ICollection<CartLine> Lines { get; set; }

        [BindNever] public int OrderId { get; set; }

        public string PaymentLink { get; set; }

        public string PaymentOrderLink { get; set; }
    }
}