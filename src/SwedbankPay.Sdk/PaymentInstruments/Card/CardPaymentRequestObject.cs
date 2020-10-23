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

        public Cardholder Cardholder { get; }
        public CreditCard CreditCard { get; }
        public CurrencyCode Currency { get; }
        public string Description { get; }
        public bool GeneratePaymentToken { get; }
        public bool GenerateReccurenceToken { get; }
        public PaymentIntent Intent { get; }
        public CultureInfo Language { get; }
        public Dictionary<string, object> Metadata { get; }
        public Operation Operation { get; }
        public PayeeInfo PayeeInfo { get; }
        public string PayerReference { get; }
        public string PaymentToken { get; }
        public List<IPrice> Prices { get; }
        public RiskIndicator RiskIndicator { get; }
        public IUrls Urls { get; }
        public string UserAgent { get; }
    }
}