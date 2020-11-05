using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentSaleResponseDto
    {
        public Uri Payment { get; set; }
        public SiwshPaymentSaleDto Sale { get; set; }
    }
}