using System;

namespace SwedbankPay.Client.Models
{
    [Flags]
    public enum PaymentOrderExpand
    {
        None = 0,
        Urls = 1,
        PayeeInfo = 2,
        Payments = 4,
        CurrentPayment = 8,
        Items = 16,
        All = 31
    }
}
