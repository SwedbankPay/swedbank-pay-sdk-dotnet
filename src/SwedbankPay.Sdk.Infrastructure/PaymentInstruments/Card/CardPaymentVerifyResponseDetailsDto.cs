using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentVerifyResponseDetailsDto
    {
        public string Id { get; set; }
        public IList<CardPaymentVerifyResponse> VerificationList { get; set; }

        internal ICardPaymentVerifyResponseDetails Map()
        {
            throw new NotImplementedException();
        }
    }
}