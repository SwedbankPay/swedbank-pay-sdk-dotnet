using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentVerifyRequest
    {
        public CardPaymentVerifyRequest(Operation operation,
                              CurrencyCode currency,
                              string description,
                              string userAgent,
                              CultureInfo language,
                              Urls urls,
                              PayeeInfo payeeInfo,
                              string payerReference = null,
                              bool generatePaymentToken = false,
                              bool generateReccurenceToken = false,
                              CreditCard creditCard = null)
        {
            this.Payment = new CardPaymentVerifyRequestObject(operation, currency, description, payerReference, generatePaymentToken,
                                               generateReccurenceToken, userAgent, language, urls, payeeInfo,
                                               creditCard);
        }


        public CardPaymentVerifyRequestObject Payment;

        public class CardPaymentVerifyRequestObject
        {
            protected internal CardPaymentVerifyRequestObject(Operation operation,
                                                    CurrencyCode currency,
                                                    string description,
                                                    string payerReference,
                                                    bool generatePaymentToken,
                                                    bool generateReccurenceToken,
                                                    string userAgent,
                                                    CultureInfo language,
                                                    Urls urls,
                                                    PayeeInfo payeeInfo,
                                                    CreditCard creditCard = null)
            {
                Operation = operation ?? throw new ArgumentNullException(nameof(operation));
                Currency = currency;
                Description = description;
                PayerReference = payerReference;
                UserAgent = userAgent;
                Language = language;
                Urls = urls;
                PayeeInfo = payeeInfo;
                CreditCard = creditCard;
                GeneratePaymentToken = generatePaymentToken;
                GenerateReccurenceToken = generateReccurenceToken;
            }


            public CreditCard CreditCard;
            public CurrencyCode Currency;
            public string Description;
            public bool GeneratePaymentToken;
            public bool GenerateReccurenceToken;
            public CultureInfo Language;
            public Operation Operation;
            public PayeeInfo PayeeInfo;
            public string PayerReference;
            public Urls Urls;
            public string UserAgent;
        }
    }
}

