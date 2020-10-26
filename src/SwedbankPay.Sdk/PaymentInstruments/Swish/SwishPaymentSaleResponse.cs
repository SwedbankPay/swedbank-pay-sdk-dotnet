using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentSaleResponse
    {
        public SwishPaymentSaleResponse(Uri payment, SiwshPaymentSale sale)
        {
            Payment = payment;
            Sale = sale;
        }


        public Uri Payment { get; }
        public SiwshPaymentSale Sale { get; }
    }
}