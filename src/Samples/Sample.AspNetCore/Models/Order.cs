using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using SwedbankPay.Sdk;

namespace Sample.AspNetCore.Models
{
    public class Order
    {
        [BindNever] public ICollection<CartLine> Lines { get; set; }

        [BindNever] public int OrderId { get; set; }

        public Uri PaymentLink { get; set; }

        public Uri PaymentOrderLink { get; set; }

        // public PaymentInstrument Instrument { get; set; }
    }
}