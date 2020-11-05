using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentAuthorizationResponseDto
    {
        public PaymentAuthorizationDto Authorization { get; set; }
        public Uri Payment { get; set; }
    }
}