using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentVerifyResponseDto
    {
        public Uri Payment { get; set; }

        public VerificationListResponseDto Verifications { get; set; }
    }
}