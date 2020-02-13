using System;
using System.Collections.Generic;
using System.Globalization;

using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Payments.CardPayments;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentRequest
    {
        public CardPaymentRequest(Operation operation,
                              Intent intent,
                              CurrencyCode currency,
                              List<Price> prices,
                              string description,
                              string userAgent,
                              CultureInfo language,
                              Urls urls,
                              PayeeInfo payeeInfo,
                              bool generatePaymentToken = false,
                              bool generateReccurenceToken = false,
                              string payerReference = null,
                              RiskIndicator riskIndicator = null,
                              Cardholder cardholder = null,
                              CreditCard creditCard = null,
                              Dictionary<string, object> metaData = null,
                              string paymentToken = null)
        {
            this.Payment = new CardPaymentRequestObject(operation, intent, currency, prices, description, payerReference, generatePaymentToken,
                                               generateReccurenceToken, userAgent, language, urls, payeeInfo, riskIndicator, cardholder,
                                               creditCard, metaData, paymentToken);
        }


        public CardPaymentRequestObject Payment;

        public class CardPaymentRequestObject
        {
            protected internal CardPaymentRequestObject(Operation operation,
                                                    Intent intent,
                                                    CurrencyCode currency,
                                                    List<Price> prices,
                                                    string description,
                                                    string payerReference,
                                                    bool generatePaymentToken,
                                                    bool generateReccurenceToken,
                                                    string userAgent,
                                                    CultureInfo language,
                                                    Urls urls,
                                                    PayeeInfo payeeInfo,
                                                    RiskIndicator riskIndicator = null,
                                                    Cardholder cardholder = null,
                                                    CreditCard creditCard = null,
                                                    Dictionary<string, object> metaData = null,
                                                    string paymentToken = null)
            {
                Operation = operation ?? throw new ArgumentNullException(nameof(operation));
                Intent = intent;
                Currency = currency;
                Prices = prices;
                Description = description;
                PayerReference = payerReference;
                UserAgent = userAgent;
                Language = language;
                Urls = urls;
                PayeeInfo = payeeInfo;
                RiskIndicator = riskIndicator;
                Cardholder = cardholder;
                CreditCard = creditCard;
                MetaData = metaData;
                GeneratePaymentToken = generatePaymentToken;
                GenerateReccurenceToken = generateReccurenceToken;
                PaymentToken = paymentToken;
            }


            public Cardholder Cardholder;
            public CreditCard CreditCard;
            public CurrencyCode Currency;
            public string Description;
            public bool GeneratePaymentToken;
            public bool GenerateReccurenceToken;
            public Intent Intent;
            public CultureInfo Language;
            public Dictionary<string, object> MetaData;
            public Operation Operation;
            public PayeeInfo PayeeInfo;
            public string PayerReference;
            public string PaymentToken;
            public List<Price> Prices;
            public RiskIndicator RiskIndicator;
            public Urls Urls;
            public string UserAgent;
        }
    }
}