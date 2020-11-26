using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentRecurRequest
    {
        public CardPaymentRecurRequest(Operation operation,
                                       PaymentIntent intent,
                                       string recurrenceToken,
                                       Currency currency,
                                       Amount amount,
                                       Amount vatAmount,
                                       string description,
                                       string userAgent,
                                       Language language,
                                       Uri callbackUrl,
                                       PayeeInfo payeeInfo,
                                       Dictionary<string, object> metadata = null)
        {
            Payment = new CardPaymentRecurPayment(operation,
                                                      intent,
                                                      recurrenceToken,
                                                      currency,
                                                      amount,
                                                      vatAmount,
                                                      description,
                                                      userAgent,
                                                      language,
                                                      callbackUrl,
                                                      payeeInfo,
                                                      metadata);
        }

        public CardPaymentRecurPayment Payment { get; }
    }
}