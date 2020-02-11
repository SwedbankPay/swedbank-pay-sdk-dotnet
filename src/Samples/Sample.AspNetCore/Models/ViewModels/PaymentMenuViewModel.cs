using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Payments.CardPayments;
using SwedbankPay.Sdk.Payments.SwishPayments;

namespace Sample.AspNetCore.Models.ViewModels
{
    public class PaymentMenuViewModel
    {
        public SwedbankPay.Sdk.Payments.CardPayments.Operations CardOperations { get; set; }
        public SwedbankPay.Sdk.Payments.SwishPayments.Operations SwishOperations { get; set; }
        public string PaymentLink { get; set; }
        public string JsSource { get; set; }
    }
}
