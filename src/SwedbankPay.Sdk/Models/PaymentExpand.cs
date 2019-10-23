namespace SwedbankPay.Sdk.Models
{
    using System;

    [Flags]
    public enum PaymentExpand
    {
        None = 0,
        Prices = 1,
        PayeeInfo = 2,
        Urls = 4,
        Transactions = 8,
        Authorizations = 16,
        Captures = 32,
        Reversals = 64,
        Cancellations = 128,
        All = 255
    }
}
