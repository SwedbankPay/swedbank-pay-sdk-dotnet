using System;
using System.Collections.Generic;
using System.Globalization;
using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentRequestObject
    {
        public CardPaymentRequestObject(Operation operation,
                                                PaymentIntent intent,
                                                CurrencyCode currency,
                                                List<IPrice> prices,
                                                string description,
                                                string payerReference,
                                                bool generatePaymentToken,
                                                bool generateReccurenceToken,
                                                string userAgent,
                                                CultureInfo language,
                                                IUrls urls,
                                                PayeeInfo payeeInfo,
                                                RiskIndicator riskIndicator = null,
                                                Cardholder cardholder = null,
                                                CreditCard creditCard = null,
                                                Dictionary<string, object> metadata = null,
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
            Metadata = metadata;
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
        public PaymentIntent Intent;
        public CultureInfo Language;
        public Dictionary<string, object> Metadata;
        public Operation Operation;
        public PayeeInfo PayeeInfo;
        public string PayerReference;
        public string PaymentToken;
        public List<IPrice> Prices;
        public RiskIndicator RiskIndicator;
        public IUrls Urls;
        public string UserAgent;
    }
}