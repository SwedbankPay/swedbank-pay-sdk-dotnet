using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentVerifyResponseDto
    {
        public string Payment { get; set; }

        public VerificationListResponseDto Verifications { get; set; }
    }
}