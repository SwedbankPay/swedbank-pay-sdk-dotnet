using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SwedbankPay.Sdk;

namespace Sample.AspNetCore.Models.ViewModels
{
    public class PaymentMenuViewModel
    {
        public SwedbankPay.Sdk.Payments.Card.Operations CardOperations { get; set; }
        public SwedbankPay.Sdk.Payments.Swish.Operations SwishOperations { get; set; }
        public string PaymentLink { get; set; }
        public string JsSource { get; set; }
    }
}
