namespace Sample.AspNetCore3.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

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