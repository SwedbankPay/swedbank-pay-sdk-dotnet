using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public interface ISiwshPaymentSale
    {
        DateTime Created { get; }
        DateTime Updated { get; }
        Uri Id { get; }
        string PaymentRequestToken { get; }
        ITransaction Transaction { get; }
    }
}