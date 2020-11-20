using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public interface ISwishPaymentSaleResponse
    {
        Uri Payment { get; }
        SwishPaymentSale Sale { get; }
    }
}