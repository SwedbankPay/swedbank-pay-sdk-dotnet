using System;
using System.Collections.Generic;
using System.Globalization;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentRecurRequest
    {
        public CardPaymentRecurRequest(Operation operation,
                                       Intent intent,
                                       string recurrenceToken,
                                       CurrencyCode currency,
                                       Amount amount,
                                       Amount vatAmount,
                                       string description,
                                       string userAgent,
                                       CultureInfo language,
                                       Uri callbackUrl,
                                       PayeeInfo payeeInfo,
                                       Dictionary<string, object> metadata = null)
        {
            this.Payment = new CardPaymentRequestObject(operation, intent, recurrenceToken, currency, amount, vatAmount, description,
                userAgent, language, callbackUrl, payeeInfo, metadata);
        }


        public CardPaymentRequestObject Payment;

        public class CardPaymentRequestObject
        {
            protected internal CardPaymentRequestObject(Operation operation,
                                                    Intent intent,
                                                    string recurrenceToken,
                                                    CurrencyCode currency,
                                                    Amount amount,
                                                    Amount vatAmount,
                                                    string description,
                                                    string userAgent,
                                                    CultureInfo language,
                                                    Uri callbackUrl,
                                                    PayeeInfo payeeInfo,
                                                    Dictionary<string, object> metadata = null)
            {
                Operation = operation ?? throw new ArgumentNullException(nameof(operation));
                Intent = intent;
                RecurrenceToken = recurrenceToken;
                Currency = currency;
                Amount = amount;
                VatAmount = vatAmount;
                Description = description;
                UserAgent = userAgent;
                Language = language;
                Urls = new UrlObject{ CallbackUrl = callbackUrl};
                PayeeInfo = payeeInfo;
                Metadata = metadata;
            }


            public Operation Operation;
            public Intent Intent;
            public string RecurrenceToken;
            public CurrencyCode Currency;
            public Amount Amount;
            public Amount VatAmount;
            public string Description;
            public string UserAgent;
            public CultureInfo Language;
            public UrlObject Urls;
            public PayeeInfo PayeeInfo;
            public Dictionary<string, object> Metadata;

            public class UrlObject
            {
                public Uri CallbackUrl;
            }
        }
    }
}