using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentRequestDto
    {
        public CardPaymentRequestDto(CardPaymentRequest paymentRequest)
        {
            Payment = new CardPaymentDetailsDto(paymentRequest.Payment);
        }

        public CardPaymentDetailsDto Payment { get; set; }
    }
}