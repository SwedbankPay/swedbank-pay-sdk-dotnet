using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public interface ISiwshPaymentSale
    {
        DateTime Date { get; }
        Uri Id { get; }
        string PaymentRequestToken { get; }
        ITransaction Transaction { get; }
    }
}