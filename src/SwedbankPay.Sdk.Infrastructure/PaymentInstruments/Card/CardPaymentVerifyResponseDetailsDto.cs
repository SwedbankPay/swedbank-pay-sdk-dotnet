using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentVerifyResponseDetailsDto
    {
        public Uri Id { get; set; }
        public IList<CardPaymentVerificationDto> VerificationList { get; set; }

        internal ICardPaymentVerifyResponseDetails Map()
        {
            return new CardPaymentVerifyResponseDetails(Id, VerificationList);
        }
    }
}