using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentRecurPayment
    {
        public CardPaymentRecurPayment(Operation operation,
                                       PaymentIntent intent,
                                       string recurrenceToken,
                                       Currency currency,
                                       Amount amount,
                                       Amount vatAmount,
                                       string description,
                                       string userAgent,
                                       Language language,
                                       IUrls urls,
                                       PayeeInfo payeeInfo,
                                       Dictionary<string, object> metadata = null)
        {
            Operation = operation;
            Intent = intent;
            RecurrenceToken = recurrenceToken;
            Currency = currency;
            Amount = amount;
            VatAmount = vatAmount;
            Description = description;
            UserAgent = userAgent;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;
            Metadata = metadata;
        }

        public Operation Operation { get; }
        public PaymentIntent Intent { get; }
        public string RecurrenceToken { get; }
        public Currency Currency { get; }
        public Amount Amount { get; }
        public Amount VatAmount { get; }
        public string Description { get; }
        public string UserAgent { get; }
        public Language Language { get; }
        public IUrls Urls { get; }
        public PayeeInfo PayeeInfo { get; }
        public Dictionary<string, object> Metadata { get; }
    }
}